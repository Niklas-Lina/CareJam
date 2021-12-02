using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObj : MonoBehaviour
{
    Renderer render;

    private void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    public void ChangeSize()
    {
        float range = (Random.Range(0.5f, 1.5f));
        gameObject.transform.localScale = new Vector3(range, range, range);
    }


    public void ChangeColor()
    {
        render.material.SetColor("_Color", Color.blue);
    }
}
