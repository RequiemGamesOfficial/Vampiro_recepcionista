using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalidadGrafica : MonoBehaviour
{
    public Toggle toggle;

    public GameObject globalVolume;

    private void Start()
    {
        if(toggle != true)
        {
            globalVolume.SetActive(false);
        }
    }

    public void ActivarPostPrecessing(bool postPrecessing)
    {
        Debug.Log("Activar");
        globalVolume.SetActive(postPrecessing);
    }

}
