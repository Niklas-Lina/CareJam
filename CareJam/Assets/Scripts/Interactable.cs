using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("the radius for player interaction")]
    public float radius = 3f;
    [Tooltip("where the player should try to move to, can be another gameobject than the interactable")]
    public Transform playerPoint;
    public Transform playerLookAtTransform;

    private void Start()
    {
        if(playerPoint == null)
        {
            playerPoint = gameObject.transform;
        }

        if (playerLookAtTransform == null)
        {
            playerLookAtTransform = gameObject.transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(playerPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(playerPoint.position, radius);
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
