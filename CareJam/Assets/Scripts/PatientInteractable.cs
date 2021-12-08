using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInteractable : Interactable
{
    public Talking talk;
    bool clicked = false;

    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public override void Interact()
    {
        if (!clicked)
        {
            talk.gameObject.SetActive(true);
            talk.StartSession(0);
            clicked = true;
            Player.GetComponent<PlayerController>().CanMove = false;
        }

        base.Interact();

        // Add a state for when the player tries to talk after the senario is done

    }

}
