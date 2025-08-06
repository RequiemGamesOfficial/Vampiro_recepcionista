using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEToButton : MonoBehaviour
{
    public GameObject objectToTrigger;
    public GameObject button;

    bool detected;
    public string message;

    //Pet
    public bool petBool;

    public FollowPlayer followPlayer;
    public bool dogBed;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)) && detected)
        {
            objectToTrigger.SendMessage(message);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!petBool)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                detected = true;
                button.SetActive(true);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("DogBed") && followPlayer.hotel)
            {
                dogBed = true;
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                if (!followPlayer.hotel)
                {
                    detected = true;
                    button.SetActive(true);
                }
                else
                {
                    if (dogBed)
                    {
                        detected = true;
                        button.SetActive(true);
                    }
                }
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!petBool)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                detected = false;
                button.SetActive(false);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("DogBed") && followPlayer.hotel)
            {
                dogBed = false;
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                detected = false;
                button.SetActive(false);
            }
        }        
    }
}
