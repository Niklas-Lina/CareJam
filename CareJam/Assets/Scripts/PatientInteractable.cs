using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInteractable : Interactable
{
    public Talking talk;
    bool clicked = false;

    private void Start()
    {
        //inget ska syans ibörjan av spelet
    }

    public override void Interact()
    {
        if (!clicked)
        {
            talk.gameObject.SetActive(true);
            talk.StartSession(0);
            clicked = true;
        }

        base.Interact();

        // Add a state for when the player tries to talk after the senario is done

    }

}
