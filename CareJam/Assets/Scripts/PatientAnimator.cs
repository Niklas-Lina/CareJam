using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public bool wave;
    public bool sitting;
    public bool laying;


    private void Start()
    {
        if(animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        if(animator != null)
        {
            if(wave)
            {
                Wave();
            }

            if(sitting)
            {
                Sit();
            }

            if(laying)
            {
                Lay();
            }
        }
    }

    public void Wave()
    {
        animator.SetTrigger("Wave");
    }

    public void Sit()
    {
        animator.SetBool("Sitting", true);
    }

    public void Lay()
    {
        animator.SetBool("Laying", true);
    }
}
