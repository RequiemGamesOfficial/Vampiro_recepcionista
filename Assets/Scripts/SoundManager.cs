using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip [] stepRight, stepLeft;
    int randomSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPaso1()
    {
        if (stepRight.Length > 0)
        {
            randomSound = Random.Range(0, stepRight.Length);
            audioSource.clip = stepRight[randomSound];
            audioSource.Play();
        }
    }
    public void PlayPaso2()
    {
        if (stepLeft.Length > 0)
        {
            randomSound = Random.Range(0, stepLeft.Length);
            audioSource.clip = stepLeft[randomSound];
            audioSource.Play();
        }
    }
}
