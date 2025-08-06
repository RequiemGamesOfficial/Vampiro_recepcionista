using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButtons : MonoBehaviour
{
    public GameObject[] buttonControl;
    bool HayControlConectado()
    {
        return Input.GetJoystickNames().Length > 0 && !string.IsNullOrEmpty(Input.GetJoystickNames()[0]);
    }

    private void Start()
    {
        if (HayControlConectado())
        {
            foreach (GameObject boton in buttonControl)
            {
                boton.SetActive(true);
            }
        }
    }
}
