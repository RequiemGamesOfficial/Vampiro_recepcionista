using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetScript : MonoBehaviour
{
    public Canvas canvasWorld;
    public GameObject globoDialogo;
    public Text text;
    public AudioSource canvaSound;

    private void Start()
    {
        canvasWorld.worldCamera = Camera.main;
    }

    public void SetDialog()
    {
        globoDialogo.SetActive(true);
        canvaSound.Play();
    }

    public void SetDialogOff()
    {
        globoDialogo.SetActive(false);
    }
}
