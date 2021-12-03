using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
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

                // stop focus on task? Maybee

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
                //Get component - if not null then - set focus and move to specified position ect
                // if we did set it as our focus

            }
        }

    }




}
