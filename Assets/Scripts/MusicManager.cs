using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipLoop;
    public float timeToLoop;
    float timer;
    bool loop;

    void Update()
    {
        if (!loop)
        {
            timer += Time.deltaTime;
            if(timer >= timeToLoop)
            {
                audioSource.clip = clipLoop;
                audioSource.Play();
                loop = true;
            }
        }
    }
}
