using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask layermaskMovement;

    public bool CanMove = true;
    Camera cam;
    PlayerMotor playerMotor;

    void Start()
    {
        cam = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        // !EventSystem.current.IsPointerOverGameObject() - does that the raycast wont get sent if over ui elements.
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && CanMove)
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
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
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
            if(newFocus != focus)
            {
                if(focus != null)
                {
                    focus.OnDefocus();
                }

                focus = newFocus; // new interactable focus gets set
                playerMotor.FollowTarget(newFocus); // make the player Motor track the interactable, works with moving interactables
            }
            
            // notify the interactable every time we click on it
            newFocus.OnFocused(transform); // Send the player transform to the interactable object
            

        }

        void RemoveFocus()
        {
            if(focus != null)
            {
                focus.OnDefocus(); // interactable sould stop tracking the players position.
                

            }

            playerMotor.StopFollowingTarget();
            focus = null;
        }

    }




}
