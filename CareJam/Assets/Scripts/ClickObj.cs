using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour
{
    public RectTransform OptionPanel;

    private void Start()
    {
        //Inga options ska synnas i borjan av spelet
        OptionPanel.gameObject.SetActive(false);
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
                    OptionPanel.gameObject.SetActive(true);

                }

            }

        }

    }
}
