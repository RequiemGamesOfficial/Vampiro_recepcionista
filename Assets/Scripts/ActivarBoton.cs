using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBoton : MonoBehaviour
{
    public GameObject objectToSendMessage;
    public string messageEnter;
    bool detected;
    public GameObject button;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)) && detected)
        {
            SendMesageToObject();
        }
    }

    public void SendMesageToObject()
    {
        objectToSendMessage.SendMessage(messageEnter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            button.SetActive(false);
        }
    }
}
