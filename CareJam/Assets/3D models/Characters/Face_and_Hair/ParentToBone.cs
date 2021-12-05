using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToBone : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if(target != null)
        {
            this.transform.parent = target;
        }
        else
        {
            Debug.Log("Transform not specified ! " + gameObject.name);
        }
        
    }
}
