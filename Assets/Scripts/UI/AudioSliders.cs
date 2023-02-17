using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSliders : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetFXVolume(float value)
    {
        masterMixer.SetFloat("FXVolumen", Mathf.Log10(value)*20);
        print(Mathf.Log10(value));
    }

    public void SetMusicVolume(float value)
    {
        masterMixer.SetFloat("MusicaVolumen", Mathf.Log10(value)*20);
        print(Mathf.Log10(value));
    }

    public void SetMasterVolume(float value)
    {
        masterMixer.SetFloat("MasterVolumen", Mathf.Log10(value) * 20);
    }
}
