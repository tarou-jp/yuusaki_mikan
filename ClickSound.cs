using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioClip[] audio_clip;
    public GameObject audio_source;

    public static ClickSound instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ClickSoundPlay(int i)
    {
        audio_source.GetComponent<AudioSource>().clip = audio_clip[i];
        audio_source.GetComponent<AudioSource>().Play();
    }
}
