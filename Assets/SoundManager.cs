using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip paso1, paso2;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPaso1()
    {
        audioSource.clip = paso1;
        audioSource.Play();
    }
    public void PlayPaso2()
    {
        audioSource.clip = paso2;
        audioSource.Play();
    }
}
