using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateAudio : MonoBehaviour
{
    public Skate skate;
    public AudioSource audioSourceLoop,audioSource;
    public AudioClip rollingLoop, grindLoop,jump,grind;


    public void PlayRollingLoopSound()
    {
        audioSourceLoop.clip = rollingLoop;
        audioSourceLoop.Play();
        Debug.Log("Play audio");
    }

    public void StopRollingLoopSound()
    {
        audioSourceLoop.Stop();
        Debug.Log("Stop audio");
    }

    public void JumpSound()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }
    public void GrindSound()
    {
        audioSource.clip = grind;
        audioSource.Play();
    }
}
