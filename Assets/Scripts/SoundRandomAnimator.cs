using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomAnimator : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    int randomSound;

    public void PlayRandomSound()
    {
        if (audioClip.Length > 0)
        {
            randomSound = Random.Range(0, audioClip.Length);
            audioSource.clip = audioClip[randomSound];
            audioSource.Play();
        }
    }
}
