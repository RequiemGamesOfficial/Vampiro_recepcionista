using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlAnimator : MonoBehaviour
{
    public Animator anim;
    public string playAnim;

    public GameObject buttonMouse, pressStart;

    bool IsControllerConnected()
    {
        string[] connectedJoysticks = Input.GetJoystickNames();

        foreach (string joystick in connectedJoysticks)
        {
            if (!string.IsNullOrEmpty(joystick))
                return true; // Al menos un mando está conectado
        }

        return false;
    }

    void Start()
    {
        if (IsControllerConnected())
        {
            Debug.Log("Mando conectado");
            buttonMouse.SetActive(false);
            pressStart.SetActive(true);
        }
        else
        {
            Debug.Log("Solo teclado/mouse");
            buttonMouse.SetActive(true);
            pressStart.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Debug.Log("Botón Start presionado");
            anim.Play(playAnim);
        }
    }
}
