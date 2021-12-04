using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _nf_test : Interactable
{
    // Script for changing color in the new render att runtime

    //Change Base color of material during runtime.
    public Color color;
    [SerializeField] MaterialPropertyBlock materialPropertyBlock;
    [SerializeField] Renderer renderer;

    public override void Interact()
    {
        ChangeColor();
        //base.Interact();
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
}
