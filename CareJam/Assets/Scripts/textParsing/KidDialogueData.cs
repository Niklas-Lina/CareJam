using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class KidDialogueData : MonoBehaviour
{
    public TextAsset twineText;
    public int currentSessionNR = 1;
    public conflict currentConflict;


    void ParseText(TextAsset txt)
    {

        //PARSE TO NODES

        string text = Regex.Replace(txt.text, "{.*?}", string.Empty);
        string[] blocks = text.Split(':');

        List<string> pathTtitles = new List<string>();
        List<string> responses = new List<string>();
        List<string> destinations = new List<string>();
        List<string> KidTxts = new List<string>();
        List<Nodes> allNodes = new List<Nodes>();

        string CurrentLine;


        for (int i = 0; i < blocks.Length; i++)
        {
            //If textblock is not empty
            if (blocks[i].Length > 0)
            {
                //create a new node for this textblock
                Nodes node = new Nodes();


                //GET QUESTION
                if (blocks[i].Contains('['))
                {

                    string[] Questions = blocks[i].Split('[', '\n');

                    string thisQuestion = string.Empty;

                    string thisDestination = string.Empty;

                    for (int f = 4; f<Questions.Length; f++ )
                    {

                        if (Questions[f].Contains("]]") || Questions[f].Contains("if $"))
                        {

                            if (Questions[f].Contains("]]"))
                            {
                                //SUPER UGLY, fix when not tired
                                CurrentLine = Questions[f].Remove(Questions[f].Length - 3);
                                //split between | to get both question and destination
                                thisQuestion = CurrentLine.Split('|', '\n')[0];

                                CurrentLine = Questions[f].Remove(Questions[f].Length - 3);
                                //last one doesn't have a destination, ignore that one
                                if (CurrentLine.Contains("|"))
                                    thisDestination = CurrentLine.Split('|', '\n')[1];



                                //No empty questions
                                if (thisQuestion != string.Empty)
                                {
                                    Question question = new Question();
                                    question.question = thisQuestion;
                                    question.destination = thisDestination;

                                    node.questions.Add(question);

                                }


                            }

                        }
                    }

                }

                //GET TITLE AND KID TEXT

                CurrentLine = blocks[i].Split('\n')[0];
                //make sure text has some text
                if (CurrentLine.Length > 1)
                {
                    node.pathTitle = blocks[i].Split('\n')[0]; 
                }


                //GET SESSION START
                if (CurrentLine.Contains("="))
                {
                        currentConflict.Opener = CurrentLine.Substring(CurrentLine.IndexOf("=") + 1); ;
                        currentConflict.SessionNr = currentSessionNR;


                }

              

                //kid response comes after the titles, one line down
                CurrentLine = blocks[i].Split('\n')[1];

                //make sure kid is saying something
                if (CurrentLine.Length > 1)
                {
                    node.KidTxt = blocks[i].Split('\n')[1];

                }


                //IS THIS A REAL NODE?
                if ( node.pathTitle != null)
                {
                    currentConflict.pathNodes.Add(node);

                }

            }


        }

       
    }


    public int GetFirstIntFromString(string Str)
    {
        string strNr = string.Empty;
        int result = -1;

        for (int i = 0; i < Str.Length; i++)
        {
            if (Char.IsDigit(Str[i]))
            {
                strNr += Str[i];
                result = int.Parse(strNr);
                return result;
            }
        }

        return result;
    }


    void Awake()
    {
        ParseText(twineText);
    }

}

[Serializable]


public class conflict
{
    public string Opener;
    public int SessionNr;
    //witch pathNode
    public List<Nodes> pathNodes = new List<Nodes>();
    public Nodes currentNode;
    public string Closer;

}

public class Nodes
{
    public string pathTitle;
    public string KidTxt;
    public List<Question> questions = new List<Question>();
}

public class Question
{
    public string question;
    public string destination;
    public bool hasData = false;
}






