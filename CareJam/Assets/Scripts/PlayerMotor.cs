using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    Transform lookAt;
    float targetRadius;
    [SerializeField] float distanceToTarget;

    NavMeshAgent agent;

    [SerializeField] float angularFollowRotationSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(target!= null)
        {
            agent.SetDestination(target.position);

            distanceToTarget = Vector3.Distance(target.position, transform.position);
            
            if(distanceToTarget < targetRadius)
            {
                agent.updateRotation = false; // dont use the navmesh system for rotation when following an interactable
                FaceTarget();
            }
            else
            {
                agent.updateRotation = true;
            }

        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (lookAt.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * angularFollowRotationSpeed);
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.stoppingDistance = 0f;
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        

        target = newTarget.playerPoint;
        lookAt = newTarget.playerLookAtTransform;
        targetRadius = newTarget.radius;
    }

    public void StopFollowingTarget()
    {
        agent.updateRotation = true;
        target = null;
    }



}
