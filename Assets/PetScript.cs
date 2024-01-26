using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetScript : MonoBehaviour
{
    public Canvas canvasWorld;
    public GameObject globoDialogo;
    public Text text;

    private void Start()
    {
        canvasWorld.worldCamera = Camera.main;
    }

    public void SetDialog(string newText)
    {
        text.text = newText;
        globoDialogo.SetActive(true);
    }

    public void SetDialogOff()
    {
        globoDialogo.SetActive(false);
    }
}
