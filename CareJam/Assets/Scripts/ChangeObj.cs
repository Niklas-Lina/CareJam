using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeObj : MonoBehaviour
{
    Renderer render;
    Image img;
    private void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        img = gameObject.GetComponent<Image>();
    }

    public void Fader(float stayTime)
    {
       StartCoroutine(FadeInOut(stayTime));
    }


    public void ChangeColor()
    {
        render.material.SetColor("_Color", Color.blue);
    }

    public IEnumerator FadeInOut (float stay)
    {
        Color FullAlpha = new Color(1, 1, 1, 1);
        Color NoAlpha = new Color(1, 1, 1, 0);
        img.color = FullAlpha;

        yield return new WaitForSeconds(stay);

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            NoAlpha = new Color(1, 1, 1, i);
            img.color = NoAlpha;
            yield return null;
        }
    }
}
