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
    bool canClick = true;
    bool txtDone = false;
    AudioSource Audio;
    public AudioClip Voice;
    int currentOpt = 0;

    private void Start()
    {
        txt = transform.GetComponentInChildren<Text>();
        Debug.Log(txt.gameObject.name);
        OptionsPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void StartSession()
    {
        Debug.Log(talk[0].line);

        StartCoroutine(TypeText(talk[currentOpt].line, txt, Voice));


    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick && txtDone)
        {


        }
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

        ShowOptions(talk[currentOpt]);
        currentOpt++;
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
}

