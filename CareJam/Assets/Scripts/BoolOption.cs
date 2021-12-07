using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolOption : MonoBehaviour
{

    Image img;

    private void Start()
    {
        //anvand text fran child
        img = transform.GetComponentInChildren<Image>();
    }

    public void Swither(int time)
    {
        StartCoroutine(SwitchOnTime(time));
    }

    public IEnumerator SwitchOnTime(int time)
    {
        yield return new WaitForSeconds(time);
       if (img.isActiveAndEnabled)
        {
            img.enabled = false;
        }
       else if (!img.isActiveAndEnabled)
        { img.enabled = true; }
        yield return null;
    }
}
