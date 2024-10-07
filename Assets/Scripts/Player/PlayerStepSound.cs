using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepSound : MonoBehaviour
{
    public AudioSource audioRight,audioLeft;
    public AudioClip[] water1, water2;
    public AudioClip[] stepRight, stepLeft;
    public AudioClip[] stepRightConcre, stepLeftConcre;
    public AudioClip[] stepRightGrass, stepLeftGrass;
    int randomSound;
    public PlayerController playerController;


    public void PlayPaso1()
    {
        if (playerController.waterState)
        {
            if (water1.Length > 0)
            {
                randomSound = Random.Range(0, water1.Length);
                audioRight.clip = water1[randomSound];
                audioRight.Play();
            }
        }
        else
        {
            if (playerController.footConcrete)
            {
                if (stepRightConcre.Length > 0)
                {
                    randomSound = Random.Range(0, stepRightConcre.Length);
                    audioRight.clip = stepRightConcre[randomSound];
                    audioRight.Play();
                }
            }
            if (playerController.footGrass)
            {
                if (stepRightGrass.Length > 0)
                {
                    randomSound = Random.Range(0, stepRightGrass.Length);
                    audioRight.clip = stepRightGrass[randomSound];
                    audioRight.Play();
                }
            }
            if (!playerController.footConcrete && !playerController.footGrass)
            {
                if (stepRight.Length > 0)
                {
                    randomSound = Random.Range(0, stepRight.Length);
                    audioRight.clip = stepRight[randomSound];
                    audioRight.Play();
                }
            }
        }        
    }
    public void PlayPaso2()
    {
        if (playerController.waterState)
        {
            if (water2.Length > 0)
            {
                randomSound = Random.Range(0, water2.Length);
                audioLeft.clip = water2[randomSound];
                audioLeft.Play();
            }
        }
        else
        {
            if (playerController.footConcrete)
            {
                if (stepLeftConcre.Length > 0)
                {
                    randomSound = Random.Range(0, stepLeftConcre.Length);
                    audioLeft.clip = stepLeftConcre[randomSound];
                    audioLeft.Play();
                }
            }
            if (playerController.footGrass)
            {
                if (stepLeftGrass.Length > 0)
                {
                    randomSound = Random.Range(0, stepLeftGrass.Length);
                    audioLeft.clip = stepLeftGrass[randomSound];
                    audioLeft.Play();
                }
            }
            if (!playerController.footConcrete && !playerController.footGrass)
            {
                if (stepLeft.Length > 0)
                {
                    randomSound = Random.Range(0, stepLeft.Length);
                    audioLeft.clip = stepLeft[randomSound];
                    audioLeft.Play();
                }
            }
        }       
    }
}
