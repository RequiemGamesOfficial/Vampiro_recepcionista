using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeLugar : MonoBehaviour
{
    bool detected;
    public string nuevoLugar;

    public Hotel hotel;

    public bool habitacion;
    public int numeroHabitacion;

    public AudioSource audioSource;
    public GameObject button;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            ChangeFloor();
        }
    }

    public void ChangeFloor()
    {
        if (nuevoLugar == "Piso1")
        {
            hotel.Piso1();
        }
        if (nuevoLugar == "Piso2")
        {
            hotel.Piso2();
        }
        if (nuevoLugar == "Piso3")
        {
            hotel.Piso3();
        }
        if (nuevoLugar == "Piso4")
        {
            hotel.Piso4();
        }

        //Habitaciones
        if (nuevoLugar == "Hombre")
        {
            hotel.HabitacionHombre(numeroHabitacion);
        }
        if (nuevoLugar == "Mujer")
        {
            hotel.HabitacionMujer(numeroHabitacion);
        }
        if (nuevoLugar == "Payaso")
        {
            hotel.HabitacionPayaso(numeroHabitacion);
        }
        if (nuevoLugar == "Padrecito")
        {
            hotel.HabitacionPadrecito(numeroHabitacion);
        }
        if (nuevoLugar == "Drogo")
        {
            hotel.HabitacionDrogo(numeroHabitacion);
        }
        if (nuevoLugar == "Mago")
        {
            hotel.HabitacionMago(numeroHabitacion);
        }
        if (nuevoLugar == "Musico")
        {
            hotel.HabitacionMusico(numeroHabitacion);
        }

        hotel.FadeToBlack();
        audioSource.Play();

        if (habitacion)
        {
            if(numeroHabitacion == 1)
            {
                hotel.habitacionActual = "habitacion1";
            }
            if (numeroHabitacion == 2)
            {
                hotel.habitacionActual = "habitacion2";
            }
            if (numeroHabitacion == 3)
            {
                hotel.habitacionActual = "habitacion3";
            }
            if (numeroHabitacion == 4)
            {
                hotel.habitacionActual = "habitacion4";
            }
        }
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
