using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeLugar2 : MonoBehaviour
{
    bool detected;
    public string nuevoLugar;

    [SerializeField]
    private EscenaInical hotel;

    public bool habitacion;
    public int numeroHabitacion;

    public AudioSource audioSource;
    public GameObject button;

    ControllerManager controllerManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            controllerManager.OffSkate(false);
            ChangeFloor();
        }
    }

    public void ChangeFloor()
    {
        if (habitacion)
        {
            hotel.habitacionActual = numeroHabitacion;
        }

        if (nuevoLugar == "Sotano")
        {
            hotel.Sotano();
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }

        if (nuevoLugar == "Piso1")
        {
            hotel.Piso1();
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Piso2")
        {
            hotel.Piso2();
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Piso3")
        {
            hotel.Piso3();
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Piso4")
        {
            hotel.Piso4();
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controllerManager = collision.GetComponent<ControllerManager>();
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
