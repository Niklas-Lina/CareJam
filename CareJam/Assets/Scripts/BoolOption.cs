using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolOption : MonoBehaviour
{
    public bool On;
    public string Ontext;
    public string Offtext;
    Text txt;

    private void Start()
    {
        //anvand text fran child
        txt = transform.GetComponentInChildren<Text>();
    }

    public void ChangeValue()
    {
        On = !On;

        if(On == true)
        {
            txt.text = Ontext;
        }
        else if (On != true)
        {
            txt.text = Offtext;
        }
    }

    public void LightSwitch(GameObject obj)
    {
       if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
       else if (!obj.activeSelf)
        { obj.SetActive(true); }
    }
}
