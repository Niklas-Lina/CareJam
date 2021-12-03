using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable interactableFocus;

    public LayerMask layermaskMovement;

    Camera cam;
    PlayerMotor playerMotor;

    void Start()
    {
        cam = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,200f,layermaskMovement))
            {
                // Move the player to what we hit
                //Debug.Log("We hit " + hit.collider.gameObject.name + "  " + hit.point);
                
                playerMotor.MoveToPoint(hit.point);

                //stop focus on task
                RemoveFocus();

            }
        }

        // Interactable object clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200f))
            {
                //Debug.Log("We hit " + hit.collider.gameObject.name + "  " + hit.point);

                // Check if we hit and interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    Debug.Log("We hit " + hit.collider.gameObject.name + "  " + hit.point);
                    SetFocus(interactable);
                }

            }
        }

        void SetFocus(Interactable newFocus)
        {
            interactableFocus = newFocus;

            //simple for stationary objects
            //playerMotor.MoveToPoint(interactableFocus.playerPoint.position);

            // for folowing dynamic objects
            playerMotor.FollowTarget(newFocus);
        }

        void RemoveFocus()
        {
            playerMotor.StopFollowingTarget();
            interactableFocus = null;
        }

    }




}
