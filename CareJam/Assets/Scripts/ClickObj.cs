using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour
{
    public Talking talk;

    private void Start()
    {
        //Inga options ska synnas i borjan av spelet
    }

    void Update()
    {

        // se om musen ar i omradet
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //klickar musen?
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    talk.gameObject.SetActive(true);
                    talk.StartSession();

                }

            }

        }

    }
}
