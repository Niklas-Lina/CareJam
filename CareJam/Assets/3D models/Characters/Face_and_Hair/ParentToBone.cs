using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToBone : MonoBehaviour
{
    public Transform target;


    const string HEADBONE = "mixamorig:Head";
    [Tooltip("Will search for the headbone name if the slot is empty")]
    public bool parentToHeadBone = true;

    // the Face and hair Geometry can have this at their root level for correct placement when animation is playing.

    private void Start()
    {
        if(target != null)
        {
            this.transform.parent = target;
        }
        else if(parentToHeadBone == true)
        {
            // get the parent Transform
            Transform parentTransform = transform.parent.GetComponentInParent<Transform>();

            // search for the name in the children
            Transform headboneTransform = ReturnTransformWithName(parentTransform, HEADBONE);



            if (headboneTransform != null)
            {
                // if found
                this.transform.parent = headboneTransform;
            }
            else
            {
                Debug.Log("cant find headbone " + gameObject.name);
            }
            
        }
        else
        {
            Debug.Log("Transform not specified ! " + gameObject.name);
        }
        
    }


    public Transform ReturnTransformWithName(Transform parentTransform, string searchString)
    {
        Transform[] children = parentTransform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.name == HEADBONE)
            {
                return child;
                break;
            }
        }

        return null;
    }



}
