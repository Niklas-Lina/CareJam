using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomationAnimationSmoothTime = 0.1f;

    Animator animator;
    NavMeshAgent agent;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // look how fast the nav Mesh Agent is moving and devide by its maximum speed to get 0-1 value
        float speedPercent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("speedPercent",speedPercent,locomationAnimationSmoothTime, Time.deltaTime);
    }
}
