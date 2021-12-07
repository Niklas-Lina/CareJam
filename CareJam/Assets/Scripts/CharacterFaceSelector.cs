using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceSelector : MonoBehaviour
{
    [SerializeField] bool tryingOutStyles;

    [SerializeField] int eyesIndex;
    [SerializeField] int noseIndex;
    [SerializeField] int eyebrowsIndex;
    [SerializeField] int hairStyleIndex;
    [SerializeField] int beardIndex;
    [SerializeField] int moustachIndex;

    [SerializeField] List<GameObject> eyesList;
    [SerializeField] List<GameObject> noseList;
    [SerializeField] List<GameObject> eyebrowsList;
    [SerializeField] List<GameObject> hairStylesList;
    [SerializeField] List<GameObject> beardList;
    [SerializeField] List<GameObject> mustachList;
    

    private void Start()
    {
        ChangeGameObject(eyesList, eyesIndex);
        ChangeGameObject(noseList, noseIndex);
        ChangeGameObject(eyebrowsList, eyebrowsIndex);
        ChangeGameObject(hairStylesList, hairStyleIndex);
        ChangeGameObject(beardList, beardIndex);
        ChangeGameObject(mustachList, moustachIndex);
    }

    private void Update()
    {
        if (tryingOutStyles)
        {
            ChangeGameObject(beardList, beardIndex);
            ChangeGameObject(eyesList, eyesIndex);
            ChangeGameObject(noseList, noseIndex);
            ChangeGameObject(eyebrowsList, eyebrowsIndex);
            ChangeGameObject(hairStylesList, hairStyleIndex);
            ChangeGameObject(beardList, beardIndex);
            ChangeGameObject(mustachList, moustachIndex);
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
}
