using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInteractable : Interactable
{
    public Talking talk;
    bool clicked = false;
    MainCtrl GameCtrl;

    public GameObject interactionMarker;

    GameObject Player;

    private void Start()
    {
        interactionMarker.SetActive(true);

        Player = GameObject.FindGameObjectWithTag("Player");
        GameCtrl = MainCtrl.gameCtrl;
    }


    public override void Interact()
    {
        if (!clicked)
        {
            interactionMarker.SetActive(false);

            talk.gameObject.SetActive(true);
            talk.StartSession(0);
            clicked = true;
            GameCtrl.PatientAmount--;
            Player.GetComponent<PlayerController>().CanMove = false;
        }

        base.Interact();

        // Add a state for when the player tries to talk after the senario is done

    }

}
