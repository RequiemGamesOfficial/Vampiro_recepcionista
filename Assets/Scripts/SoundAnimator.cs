using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnimator : MonoBehaviour
{
    public PlayerController playerController;
    
    public AudioSource audioSource1,audioSource2;
    private bool useFirstSource = true; // Variable para alternar entre los AudioSources

    public AudioClip audio1, audio2, audio3, audio4;
    public AudioClip swimming;

    int randomSound;
    public AudioClip[] climbing;

    public void PlayAudioClip01()
    {
        if(audio1 != null)
        {
            audioSource1.clip = audio1;
            audioSource1.Play();
        }
    }
    public void PlayAudioClip02()
    {
        if (audio2 != null)
        {
            audioSource1.clip = audio2;
            audioSource1.Play();
        }
    }
    public void PlayAudioClip03()
    {
        if (audio3 != null)
        {
            audioSource1.clip = audio3;
            audioSource1.Play();
        }
    }
    public void PlayAudioClip04()
    {        
        if (playerController.waterState)
        {
            audioSource1.clip = swimming;
            audioSource1.Play();
        }
        else
        {
            audioSource1.clip = audio4;
            audioSource1.Play();
        }
    }

    public void PlayClimbingAudio()
    {
        if (climbing.Length > 0)
        {
            randomSound = Random.Range(0, climbing.Length);
            if (useFirstSource)
            {
                audioSource1.clip = climbing[randomSound];
                audioSource1.Play();
            }
            else
            {
                audioSource2.clip = climbing[randomSound];
                audioSource2.Play();
            }

            useFirstSource = !useFirstSource; // Cambia el valor para la próxima vez
        }
    }
}
