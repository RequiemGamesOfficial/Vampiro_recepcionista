using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip seleccion, audioSi,audioNo,audioLlave;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioSeleccion()
    {
        audioSource.clip = seleccion;
        audioSource.Play();
    }
    public void PlayAudioSi()
    {
        audioSource.clip = audioSi;
        audioSource.Play();
    }
    public void PlayAudioNo()
    {
        audioSource.clip = audioNo;
        audioSource.Play();
    }
    public void PlayAudioLlave()
    {
        audioSource.clip = audioLlave;
        audioSource.Play();
    }
}
