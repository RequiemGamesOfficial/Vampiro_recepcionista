using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEToButton : MonoBehaviour
{
    public GameObject objectToTrigger;
    public GameObject button;
    bool detected;
    public string message;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            objectToTrigger.SendMessage(message);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enter");
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
