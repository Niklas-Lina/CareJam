using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talking : MonoBehaviour
{
    [SerializeField] public TalkOption[] talk;
    public GameObject OptionsPanel;
    Text txt;
    AudioSource Audio;
    public AudioClip Voice;
    int currentOpt = 0;
    bool end = false;
    Image bubbleImg;
    GameObject Player;
    MainCtrl ctrl;

    private void Start()
    {
        txt = transform.GetComponentInChildren<Text>();
        OptionsPanel.SetActive(false);
        gameObject.SetActive(false);
        bubbleImg = transform.GetComponent<Image>();
        Player = GameObject.FindGameObjectWithTag("Player");
        ctrl = MainCtrl.gameCtrl;
    }

    public void StartSession(int nr)
    {
        string firstLine = talk[nr].line;
        StartCoroutine(TypeText(firstLine, txt, Voice, 0));

    }

    public void Answer(int nr)
    {
        StartCoroutine(TypeText(talk[currentOpt].Answers[nr], txt, Voice, talk[currentOpt].Pause[nr]));
        //Ga vidare till nasta options
        currentOpt++;
    }


    IEnumerator TypeText(string message, Text txtObj, AudioClip voice, int startPause)
    {
        bubbleImg.enabled = false;
        txt.enabled = false;
        yield return new WaitForSeconds(startPause);

        bubbleImg.enabled = true;
        txt.enabled = true;
        //sa att inga gamla options syns
        foreach (Transform child in OptionsPanel.transform)
        {
            child.gameObject.SetActive(false);
        }
        //Texten borjar fran 0
        int index = 0;
        //Allt ar genomskinligt i borjan
        string colorTag = "<color=#00000000>";

        if (message.Contains("*"))
        {
            end = true;
            message = message.Remove(message.Length - 1);
        }

            //Ifall face shader
            /*
            if (Faces != null)
            { Faces.talking = true; } */
            float pause = 0.03f;
        txtObj.text = "";

        if (voice != null)
        {
            Audio.clip = voice;
            Audio.Play();
        }

        while (index <= message.Length)
        {
            string txt = message.Substring(0, index) + colorTag + message.Substring(index) + "</color>";
            txtObj.text = txt;
            index++;

            if (txt.EndsWith(".") || txt.EndsWith("!") || txt.EndsWith("?"))
            {
                pause = 0.5f;

            }
            else
                pause = 0.03f;

            yield return new WaitForSeconds(pause);
        }

        //Faces.talking = false;

        //@ at the end means no more options
        if (!end)
        { ShowOptions(talk[currentOpt]); }

        //om slut, ta bort bubbla efter 3 sekunder
        if(end)
        { 
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);

            if (ctrl.PatientAmount <= 0)
            {
                ctrl.END = true;
            }
            Player.GetComponent<PlayerController>().CanMove = true;

        }
        yield return 0;
    }

    public void ShowOptions (TalkOption chat)
    {
        OptionsPanel.SetActive(true);
        for (int i= 0; i < chat.options.Length; i++)
        {
            chat.options[i].gameObject.SetActive(true);
        }

    }

}

[Serializable]

public class TalkOption
{
    public string line;
    public RectTransform[] options;
    public string[] Answers;
    public int[] Pause;
}

