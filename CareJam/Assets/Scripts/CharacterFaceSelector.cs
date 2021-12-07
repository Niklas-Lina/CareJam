using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceSelector : MonoBehaviour
{
    [SerializeField] bool tryingOutStyles;

    [Header("SetUp Meshes")]
    [SerializeField] SkinnedMeshRenderer[] skinMeshRenderer;
    [SerializeField] MeshRenderer[] hairMeshRenderer;
    [SerializeField] SkinnedMeshRenderer[] shirtMeshRenderer;
    [SerializeField] SkinnedMeshRenderer[] pantsMeshRenderer;
    [SerializeField] MeshRenderer[] noseMeshRenderer;
    [SerializeField] MeshRenderer[] eyeWearMeshRenderer;

    [Header("Colors")]
    [SerializeField] int skinColorIndex;
    [SerializeField] int hairColorIndex;
    [SerializeField] int shirtColorIndex;
    [SerializeField] int pantsColorIndex;
    [SerializeField] int noseColorIndex;
    [SerializeField] int eyeWearColorIndex;

    [SerializeField] List<Color> skinColorsList;
    [SerializeField] List<Color> hairColorsList;
    [SerializeField] List<Color> shirtColorList;
    [SerializeField] List<Color> pantsColorList;
    [SerializeField] List<Color> noseColorList;
    [SerializeField] List<Color> eyeWearColorList;


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

    MaterialPropertyBlock materialPropertyBlock;


    private void Start()
    {
        UpdateApparance();
    }

    private void UpdateApparance()
    {
        //Change Color
        hairColorIndex = ValidateIndex(hairColorsList,hairColorIndex);
        ChangeColor(hairMeshRenderer, hairColorsList,hairColorIndex);
        
        skinColorIndex = ValidateIndex(skinColorsList, skinColorIndex);
        ChangeColor(skinMeshRenderer, skinColorsList,skinColorIndex);
        
        shirtColorIndex = ValidateIndex(shirtColorList, shirtColorIndex);
        ChangeColor(shirtMeshRenderer, shirtColorList,shirtColorIndex);
        
        pantsColorIndex = ValidateIndex(pantsColorList, pantsColorIndex);
        ChangeColor(pantsMeshRenderer, pantsColorList,pantsColorIndex);
        
        noseColorIndex = ValidateIndex(noseColorList, noseColorIndex);
        ChangeColor(noseMeshRenderer, noseColorList, noseColorIndex);

        eyeWearColorIndex = ValidateIndex(eyeWearColorList, eyeWearColorIndex);
        ChangeColor(eyeWearMeshRenderer, eyeWearColorList, eyeWearIndex);

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



    public void ChangeColor(MeshRenderer[] renderers,List<Color> colorList, int selectionIndex)
    {
        if (renderers.Length > 0 && colorList.Count > 0)
        {
            // validate Index and set color
            selectionIndex = ValidateIndex(colorList, selectionIndex);
            Color color = colorList[selectionIndex];

            // Change Color for all objects
            materialPropertyBlock = new MaterialPropertyBlock();
            materialPropertyBlock.SetColor("_BaseColor", color);

            foreach (MeshRenderer rendMesh in renderers)
            {
                rendMesh.SetPropertyBlock(materialPropertyBlock);
            }
        }
        else
        {
            //no meshes added
        }

    }

    public void ChangeColor(SkinnedMeshRenderer[] renderers, List<Color> colorList, int selectionIndex)
    {
        if (renderers.Length > 0 && colorList.Count > 0)
        {
            // validate Index and set color
            selectionIndex = ValidateIndex(colorList, selectionIndex);
            Color color = colorList[selectionIndex];

            // Change Color for all objects
            materialPropertyBlock = new MaterialPropertyBlock();
            materialPropertyBlock.SetColor("_BaseColor", color);

            foreach (SkinnedMeshRenderer rendMesh in renderers)
            {
                rendMesh.SetPropertyBlock(materialPropertyBlock);
            }
        }
        else
        {
            //no meshes added
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


    /* //Random Color code
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
