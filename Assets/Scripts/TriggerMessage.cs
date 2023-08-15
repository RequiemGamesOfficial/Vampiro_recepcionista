using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMessage : MonoBehaviour
{
    public GameObject objectToSendMessage;
    public string messageEnter, messageExit;
    public bool exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToSendMessage.SendMessage(messageEnter);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && exit)
        {
            objectToSendMessage.SendMessage(messageExit);
        }
    }
}
