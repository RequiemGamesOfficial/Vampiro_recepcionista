using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalidadGrafica : MonoBehaviour
{
    public Toggle toggle;

    public GameObject globalVolume;

    public void ActivarPostPrecessing(bool postPrecessing)
    {
        Debug.Log("Activar");
        globalVolume.SetActive(postPrecessing);
    }

}
