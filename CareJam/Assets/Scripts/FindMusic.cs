using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMusic : MonoBehaviour
{
   Soundtrack soundtrack;


    public void GetSetVolume(float volume)
    {
        if (Soundtrack.musicCtrl == null)
        {
            Debug.Log("this didn't work");
            return;
        }

        soundtrack = Soundtrack.musicCtrl;

        soundtrack.ChangeVolume(volume);
    }

}
