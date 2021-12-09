using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInteractable : Interactable
{
    public Talking talk;
    bool clicked = false;
    MainCtrl ctrl;

    public GameObject interactionMarker;

    GameObject Player;

    private void Start()
    {
        interactionMarker.SetActive(true);

        Player = GameObject.FindGameObjectWithTag("Player");

        //ctrl = MainCtrl.gameCtrl;
        GameObject levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManager != null)
        {
            ctrl = levelManager.GetComponent<MainCtrl>();
            if (ctrl == null)
            {
                Debug.LogError("No MainCtrl component on the level manager");
            }
        }
        else
        {
            Debug.LogError("No Level Manager in Scene! Add the Level Manager Prefab!");
        }
    }


    public override void Interact()
    {
        if (!clicked)
        {
            interactionMarker.SetActive(false);

            talk.gameObject.SetActive(true);
            talk.StartSession(0);
            clicked = true;
            ctrl.PatientAmount--;
            Player.GetComponent<PlayerController>().CanMove = false;
        }

        base.Interact();

        // Add a state for when the player tries to talk after the senario is done

    }

}
