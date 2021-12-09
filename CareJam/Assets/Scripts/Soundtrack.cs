using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Soundtrack : MonoBehaviour
{
    public AudioMixer mixer;
    public static Soundtrack musicCtrl;
    private AudioSource audioS;
    private void Awake()
    {

        if (musicCtrl == null)
        { musicCtrl = this; }
        else if (musicCtrl != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioS = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audioS.isPlaying) return;
        audioS.Play();
    }

    public void StopMusic()
    {
        audioS.Stop();
    }

    public void ChangeVolume(float Volume)
    {
        //konverterar till logarithmic
        mixer.SetFloat("MusicVol", Mathf.Log10(Volume)*20);
    }
}

