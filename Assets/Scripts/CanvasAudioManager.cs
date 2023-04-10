using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioclip1, audioclip2;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio1()
    {
        audioSource.clip = audioclip1;
        audioSource.Play();
    }
    public void PlayAudio2()
    {
        audioSource.clip = audioclip2;
        audioSource.Play();
    }
}
