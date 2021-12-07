using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceSelector : MonoBehaviour
{
    [SerializeField] bool tryingOutStyles;

    [Header("SetUp")]
    [SerializeField] SkinnedMeshRenderer[] skinMeshRenderer;
    [SerializeField] MeshRenderer[] hairMeshRenderer;
    [SerializeField] SkinnedMeshRenderer[] shirtMeshRenderer;

    [Header("Colors")]
    [SerializeField] int skinColorIndex;
    [SerializeField] int hairColorIndex;
    [SerializeField] int shirtColorIndex;

    [SerializeField] List<Color> skinColorsList;
    [SerializeField] List<Color> hairColorsList;
    [SerializeField] List<Color> shirtColorList;

    [Header("Apparance")]
    [SerializeField] int hairStyleIndex;
    [SerializeField] int eyebrowsIndex;
    [SerializeField] int eyesIndex;
    [SerializeField] int eyeWearIndex;
    [SerializeField] int noseIndex;
    [SerializeField] int beardIndex;
    [SerializeField] int moustachIndex;

    [SerializeField] List<GameObject> hairStylesList;
    [SerializeField] List<GameObject> eyebrowsList;
    [SerializeField] List<GameObject> eyesList;
    [SerializeField] List<GameObject> eyeWearList;
    [SerializeField] List<GameObject> noseList;
    [SerializeField] List<GameObject> beardList;
    [SerializeField] List<GameObject> mustachList;


    Color currentHairColor;
    Color currentSkincolor;
    Color currentShirtColor;

    MaterialPropertyBlock materialPropertyBlock;


    private void Start()
    {
        UpdateApparance();
    }

    private void UpdateApparance()
    {
        //Change Color
        hairColorIndex = ValidateIndex(hairColorsList, hairColorIndex);
        currentHairColor = hairColorsList[hairColorIndex];
        ChangeColor(hairMeshRenderer, currentHairColor);

        skinColorIndex = ValidateIndex(skinColorsList, skinColorIndex);
        currentSkincolor = skinColorsList[skinColorIndex];
        ChangeColor(skinMeshRenderer, currentSkincolor);

        shirtColorIndex = ValidateIndex(shirtColorList, shirtColorIndex);
        currentShirtColor = shirtColorList[shirtColorIndex];
        ChangeColor(shirtMeshRenderer, currentShirtColor);


        //Change Apparance
        hairStyleIndex = ValidateIndex(hairStylesList, hairStyleIndex);
        ChangeGameObject(hairStylesList, hairStyleIndex);

        eyebrowsIndex = ValidateIndex(eyebrowsList, eyebrowsIndex);
        ChangeGameObject(eyebrowsList, eyebrowsIndex);

        eyesIndex = ValidateIndex(eyesList, eyesIndex);
        ChangeGameObject(eyesList, eyesIndex);

        eyeWearIndex = ValidateIndex(eyeWearList, eyeWearIndex);
        ChangeGameObject(eyeWearList, eyeWearIndex);

        noseIndex = ValidateIndex(noseList, noseIndex);
        ChangeGameObject(noseList, noseIndex);

        beardIndex = ValidateIndex(beardList, beardIndex);
        ChangeGameObject(beardList, beardIndex);

        moustachIndex = ValidateIndex(mustachList, moustachIndex);
        ChangeGameObject(mustachList, moustachIndex);
    }

    private void Update()
    {
        if (tryingOutStyles)
        {
            UpdateApparance();
        }
    }

    public void DisableGameObjectInList(List<GameObject> listOfGameObjects)
    {
        foreach(GameObject go in listOfGameObjects)
        {
            go.SetActive(false);
        }
    }


    public void ChangeGameObject(List<GameObject> listOfGameObjects, int selectionIndex)
    {
        if (selectionIndex > listOfGameObjects.Count)
        {
            selectionIndex = listOfGameObjects.Count;
        }
        if (selectionIndex <= 0)
        {
            selectionIndex = 0;
        }

        for (int i = 0; i < listOfGameObjects.Count; i++)
        {

            if (i == selectionIndex)
            {
                listOfGameObjects[i].SetActive(true);
            }
            else
            {
                listOfGameObjects[i].SetActive(false);
            }
        }
    }

    public int ValidateIndex(List<Color> listOfColors, int selectionIndex)
    {
        if (selectionIndex >= listOfColors.Count)
        {
            selectionIndex = listOfColors.Count -1 ;
        }
        if (selectionIndex <= 0)
        {
            selectionIndex = 0;
        }
        return selectionIndex;
    }

    public int ValidateIndex(List<GameObject> listOfGameObjects, int selectionIndex)
    {
        if (selectionIndex >= listOfGameObjects.Count)
        {
            selectionIndex = listOfGameObjects.Count - 1;
        }
        if (selectionIndex <= 0)
        {
            selectionIndex = 0;
        }
        return selectionIndex;
    }

        private void ChangeColor(MeshRenderer[] renderers,Color color)
    {
        materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetColor("_BaseColor", color);

        foreach (MeshRenderer rendMesh in renderers)
        {
            rendMesh.SetPropertyBlock(materialPropertyBlock);
        }
        // Both works
        //renderer.material.SetColor("_BaseColor", color);
    }

    private void ChangeColor(SkinnedMeshRenderer[] renderers, Color color)
    {
        materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetColor("_BaseColor", color);

        foreach (SkinnedMeshRenderer rendMesh in renderers)
        {
            rendMesh.SetPropertyBlock(materialPropertyBlock);
        }
        // Both works
        //renderer.material.SetColor("_BaseColor", color);
    }

    /*
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

    }*/

}
