using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialogue : MonoBehaviour
{
    public static DisplayDialogue DispD;
    GameObject Kid;
    [HideInInspector] public conflict CD;
    Text KidsTxt;
    public RectTransform BubbleTrans1;
    public RectTransform BubbleTrans2;
    RectTransform currentBubble;
    public GameObject AnswerPrefab;
    public GameObject PlayerPanel;

    AudioSource Audio;
    public AudioClip ClientVoice;
    public AudioClip PlayerVoice;
    //public Image readyButton;

    GameObject startQ;

    bool txtDone = true;
    bool KidAnswer = false;
    string nextSentence = string.Empty;
    int currentSenNr = 0;
    int fullSentanceNr = -1;

    Nodes currentNode;

    bool canClick = true;

    private void Awake()
    {

        if (DispD == null)
        { DispD = this; }
        else if (DispD != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        Audio = gameObject.GetComponent<AudioSource>();

    }

    private void Start()
    {

    }


    private void Update()
    {
        //readyButton.enabled = canClick;

        if (Kid != null)
        {
            if (KidAnswer && !txtDone)
            {
                if (Input.GetMouseButtonDown(0) && canClick)
                {
                    currentSenNr += 1;

                    if (currentSenNr >= fullSentanceNr)
                    {
                        txtDone = true;
                        Question(currentNode);
                        KidAnswer = false;
                        currentSenNr = 0;
                    }
                    else
                    {
                        Debug.Log(1);
                        nextSentence = SentenceCut(currentSenNr, currentNode.KidTxt);
                        setBubble(nextSentence);
                        StartCoroutine(TypeText(nextSentence, KidsTxt, null));
                    }

                }

            }
        }


    }

    public void AskQuestion(string question, string path)
    {

        Nodes nextNode = null;
        GameObject q = createQuestion(question);
        Debug.Log(q);

        if (q != null)
        {
            for (int i = 0; i < CD.pathNodes.Count; i++)
            {
                if (CD.pathNodes[i].pathTitle.Contains(path))
                {
                    nextNode = CD.pathNodes[i];
                }
            }

            q.GetComponent<Button>().onClick.AddListener(() => { SetPath(nextNode); });
        }
    }

    public void SetPath(Nodes node)
    {
        foreach (Transform child in PlayerPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        CD.currentNode = node;
        Debug.Log(node);

        if (node.KidTxt.Contains("<"))
        {
            currentBubble.gameObject.SetActive(false);
            string result = node.KidTxt.Split('<', '"')[1];
            string name = node.KidTxt.Split('"', '"')[1];
            int nr = CD.SessionNr;

            //Det har var for att avsluta det spelet
            /*
            EndofGame.End ending = new EndofGame.End { endResult = result, KidName = name, SessionNr = nr };
            Ending.endings.Add(ending);
            currentBubble.gameObject.SetActive(false);

            GC.Talking = false;*/

        }
        else
        {
            currentNode = node;

            KidAnswer = true;

            nextSentence = SentenceCut(currentSenNr, currentNode.KidTxt);
            setBubble(nextSentence);
            StartCoroutine(TypeText(nextSentence, KidsTxt, null));
        }
    }


    string SentenceCut(int nextnr, string Wholetxt)
    {
        string chop = Wholetxt;
        string[] sentances = chop.Split('*');
        fullSentanceNr = sentances.Length;

        return sentances[nextnr];

    }

    void StartSession(conflict s)
    {
        Destroy(startQ);

        txtDone = false;
        Debug.Log(CD.currentNode);
        SetPath(CD.currentNode);

    }


    void Question(Nodes node)
    {
        for (int i = 0; i < CD.currentNode.questions.Count; i++)
        {
            AskQuestion(node.questions[i].question, node.questions[i].destination);
        }
    }


    GameObject createQuestion(string Questiontxt)
    {
        GameObject q = Instantiate(AnswerPrefab, PlayerPanel.transform.position, Quaternion.identity) as GameObject;
        q.transform.SetParent(PlayerPanel.transform);
        q.GetComponentInChildren<Text>().text = Questiontxt;
        return q;
    }


    IEnumerator TypeText(string message, Text txtObj, AudioClip voice)
    {
        canClick = false;
        txtDone = false;
        int index = 0;
        string colorTag = "<color=#00000000>";
        //Ifall face shader
        /*
        if (Faces != null)
        { Faces.talking = true; } */
        float pause = 0.03f;
        txtObj.text = "";
        //Bubbleresize(message.Length + 1, trans);

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

            if (txt.EndsWith(".") || txt.EndsWith("."))
            {
                pause = 0.5f;

            }
            else
                pause = 0.03f;

            yield return new WaitForSeconds(pause);
        }

        canClick = true;
        //Faces.talking = false;
        currentSenNr += 1;
        yield return 0;
    }



    public void SetKid(GameObject kid)
    {
        Kid = kid;
        CD = Kid.GetComponent<KidDialogueData>().currentConflict;


            startQ = createQuestion(CD.Opener);
            startQ.GetComponent<Button>().onClick.AddListener(delegate { StartSession(CD); });
            CD.currentNode = CD.pathNodes[0];
            currentNode = CD.pathNodes[0];
            Debug.Log(CD.pathNodes[0].KidTxt);

    }

    //Se till att ratt pratbubbla anvands
    void setBubble(string text)
    {
        if (currentBubble != null)
        { currentBubble.gameObject.SetActive(false); }

        if (text[0] == '&')
        {
            currentBubble = BubbleTrans1;
            
        }
        else if (text[0] == '%')
        {
            currentBubble = BubbleTrans2;
        }
        KidsTxt = currentBubble.GetComponentInChildren<Text>();
        currentBubble.gameObject.SetActive(true);
        //readyButton.transform.SetParent(currentBubble);
    }

}