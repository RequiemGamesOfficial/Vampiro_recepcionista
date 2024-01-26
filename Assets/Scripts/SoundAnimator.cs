using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnimator : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audio1, audio2, audio3, audio4;

    public void PlayAudioClip01()
    {
        if(audio1 != null)
        {
            audioSource.clip = audio1;
            audioSource.Play();
        }
    }
    public void PlayAudioClip02()
    {
        if (audio2 != null)
        {
            audioSource.clip = audio2;
            audioSource.Play();
        }
    }
    public void PlayAudioClip03()
    {
        if (audio3 != null)
        {
            audioSource.clip = audio3;
            audioSource.Play();
        }
    }
    public void PlayAudioClip04()
    {
        if (audio4 != null)
        {
            audioSource.clip = audio4;
            audioSource.Play();
        }
    }
}
