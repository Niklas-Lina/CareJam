using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour
{
    public Talking talk;
    bool clicked = false;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        // se om musen ar i omradet
        if (Input.GetMouseButton(0) && !clicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //klickar musen?
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    talk.gameObject.SetActive(true);
                    talk.StartSession(0);
                    clicked = true;
                    Player.GetComponent<PlayerController>().CanMove = false;

                }

            }

        }

    }
}
