using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] stepRight, stepLeft;
    public AudioClip water1, water2;
    int randomSound;

    public FollowPlayer followPlayer;
    bool water;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPaso1()
    {
        if (followPlayer.waterState)
        {
            audioSource.clip = water1;
            audioSource.Play();
        }
        else
        {
            if (stepRight.Length > 0)
            {
                randomSound = Random.Range(0, stepRight.Length);
                audioSource.clip = stepRight[randomSound];
                audioSource.Play();
            }
        }
    }
    public void PlayPaso2()
    {
        if (followPlayer.waterState)
        {
            audioSource.clip = water2;
            audioSource.Play();
        }
        else
        {
            randomSound = Random.Range(0, stepLeft.Length);
            audioSource.clip = stepLeft[randomSound];
            audioSource.Play();
        }
    }
}
