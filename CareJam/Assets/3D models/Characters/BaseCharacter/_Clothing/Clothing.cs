using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    public SkinnedMeshRenderer targetMesh;

    public SkinnedMeshRenderer shirtSkinnedMesh;


    private void Start()
    {
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(shirtSkinnedMesh);

        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

    }


}
