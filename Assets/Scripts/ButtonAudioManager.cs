using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioManager : MonoBehaviour
{
    CanvasAudioManager canvasAudioManager;

    private void Start()
    {
        canvasAudioManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasAudioManager>();
    }

    public void PlayAudio1()
    {
        canvasAudioManager.PlayAudioSeleccion();
    }
    public void PlayAudio2()
    {
        canvasAudioManager.PlayAudioSi();
    }
}
