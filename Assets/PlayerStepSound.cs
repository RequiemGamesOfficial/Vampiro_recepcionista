using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip water1, water2;
    public AudioClip[] stepRight, stepLeft;
    public AudioClip[] stepRightConcre, stepLeftConcre;
    public AudioClip[] stepRightGrass, stepLeftGrass;
    int randomSound;
    public PlayerController playerController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPaso1()
    {
        if (playerController.waterState)
        {
            audioSource.clip = water1;
            audioSource.Play();
        }
        else
        {
            if (playerController.footConcrete)
            {
                if (stepRightConcre.Length > 0)
                {
                    randomSound = Random.Range(0, stepRightConcre.Length);
                    audioSource.clip = stepRightConcre[randomSound];
                    audioSource.Play();
                }
            }
            if (playerController.footGrass)
            {
                if (stepRightGrass.Length > 0)
                {
                    randomSound = Random.Range(0, stepRightGrass.Length);
                    audioSource.clip = stepRightGrass[randomSound];
                    audioSource.Play();
                }
            }
            if (!playerController.footConcrete && !playerController.footGrass)
            {
                if (stepRight.Length > 0)
                {
                    randomSound = Random.Range(0, stepRight.Length);
                    audioSource.clip = stepRight[randomSound];
                    audioSource.Play();
                }
            }
        }        
    }
    public void PlayPaso2()
    {
        if (playerController.waterState)
        {
            audioSource.clip = water2;
            audioSource.Play();
        }
        else
        {
            if (playerController.footConcrete)
            {
                if (stepLeftConcre.Length > 0)
                {
                    randomSound = Random.Range(0, stepLeftConcre.Length);
                    audioSource.clip = stepLeftConcre[randomSound];
                    audioSource.Play();
                }
            }
            if (playerController.footGrass)
            {
                if (stepLeftGrass.Length > 0)
                {
                    randomSound = Random.Range(0, stepLeftGrass.Length);
                    audioSource.clip = stepLeftGrass[randomSound];
                    audioSource.Play();
                }
            }
            if (!playerController.footConcrete && !playerController.footGrass)
            {
                if (stepLeft.Length > 0)
                {
                    randomSound = Random.Range(0, stepLeft.Length);
                    audioSource.clip = stepLeft[randomSound];
                    audioSource.Play();
                }
            }
        }       
    }
}
