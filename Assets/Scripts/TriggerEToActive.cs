using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEToActive : MonoBehaviour
{
    public GameObject gameObjectToSetActive;
    public GameObject button;
    bool detected;
    public bool hotel;
    bool timeOver;
    public TimerHotel timerHotel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected || Input.GetKeyUp(KeyCode.JoystickButton2) && detected)
        {
            if (hotel && !timeOver)
            {
                timeOver = true;
                timerHotel.TimeOver();
            }
            
            if(!hotel)
            {
                Continuar();
            }            
        }
    }

    public void Continuar()
    {
        Time.timeScale = 0;
        gameObjectToSetActive.SetActive(true);
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
