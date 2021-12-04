using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("the radius for player interaction")]
    public float radius = 3f;
    [Tooltip("the point the player moves to, can be another transform than the interactable")]
    public Transform interactionPoint;
    [Tooltip("The point towards the player looks when inside the radius")]
    public Transform playerLookAtTransform;

    // interaction variables
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;


    public virtual void Interact()
    {
        //This method is ment to be overridden
        Debug.Log("INTERACT with : " + gameObject.name);
    }

    private void Start()
    {
        if(interactionPoint == null)
        {
            interactionPoint = gameObject.transform;
        }

        if (playerLookAtTransform == null)
        {
            playerLookAtTransform = gameObject.transform;
        }
    }


    private void Update()
    {
        if(isFocus && hasInteracted == false)
        {
            float distance = Vector3.Distance(interactionPoint.position, player.position);
            //If the player is within the interactable radius interact
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocus()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;

        //TODO - cleanup walk trigger?
        //GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetTrigger("Walk"); // for forcing animations on the player to stop,  BUGGY
    }

    private void OnDrawGizmosSelected()
    {
        if(interactionPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactionPoint.position, radius);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        float lookAtRadius = 0.2f;
        if (playerLookAtTransform != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(playerLookAtTransform.position, lookAtRadius);
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, lookAtRadius);
        }

    }


}
