using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _nf_test : Interactable
{
    // Script for changing color in the new render att runtime

    //Change Base color of material during runtime.
    public Color color;
    public Color[] colorArray;

    [SerializeField] MaterialPropertyBlock materialPropertyBlock;
    [SerializeField] Renderer renderer;


    public override void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<Animator>().SetTrigger("Wave");

        //  TODO abort animation when klicking walk again.
        //player.GetComponentInChildren<Animator>().ResetTrigger("Wave");

        //ChangeColor();
        RandomColor();

        base.Interact();
    }

    private void Start()
    {
        //Change Color Chache
        materialPropertyBlock = new MaterialPropertyBlock();
        renderer = GetComponent<Renderer>();
    }


    private void ChangeColor()
    {
        materialPropertyBlock.SetColor("_BaseColor", color);

        renderer.SetPropertyBlock(materialPropertyBlock);

        // Both works

        //renderer.material.SetColor("_BaseColor", color);
    }

    private void RandomColor()
    {
        //Change Color Chache
        materialPropertyBlock = new MaterialPropertyBlock();

        if (colorArray != null)
        {
            int randomNumber = Random.Range(0, colorArray.Length);
            Debug.Log(randomNumber);

            color = colorArray[randomNumber];
        }

        materialPropertyBlock.SetColor("_BaseColor", color);

        renderer.SetPropertyBlock(materialPropertyBlock);

    }
}
