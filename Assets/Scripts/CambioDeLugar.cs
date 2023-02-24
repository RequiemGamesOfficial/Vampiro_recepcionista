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
        if (nuevoLugar == "Man")
        {
            hotel.HabitacionHombre(numeroHabitacion);
        }
        if (nuevoLugar == "Women")
        {
            hotel.HabitacionMujer(numeroHabitacion);
        }
        if (nuevoLugar == "Clown")
        {
            hotel.HabitacionPayaso(numeroHabitacion);
        }
        if (nuevoLugar == "Priest")
        {
            hotel.HabitacionPadrecito(numeroHabitacion);
        }
        if (nuevoLugar == "Junkie")
        {
            hotel.HabitacionDrogo(numeroHabitacion);
        }
        if (nuevoLugar == "Magician")
        {
            hotel.HabitacionMago(numeroHabitacion);
        }
        if (nuevoLugar == "Musician")
        {
            hotel.HabitacionMusico(numeroHabitacion);
        }
        //
        if (nuevoLugar == "Astronaut")
        {
            hotel.HabitacionAstronaut(numeroHabitacion);
        }
        if (nuevoLugar == "Blind")
        {
            hotel.HabitacionBlind(numeroHabitacion);
        }
        if (nuevoLugar == "Eskimo")
        {
            hotel.HabitacionEskimo(numeroHabitacion);
        }
        if (nuevoLugar == "Explorer")
        {
            hotel.HabitacionExplorer(numeroHabitacion);
        }
        if (nuevoLugar == "Alien")
        {
            hotel.HabitacionAlien(numeroHabitacion);
        }
        if (nuevoLugar == "Castaway")
        {
            hotel.HabitacionCastaway(numeroHabitacion);
        }
        if (nuevoLugar == "Skater")
        {
            hotel.HabitacionSkater(numeroHabitacion);
        }
        if (nuevoLugar == "Samurai")
        {
            hotel.HabitacionSamurai(numeroHabitacion);
        }
        if (nuevoLugar == "Tesla")
        {
            hotel.HabitacionTesla(numeroHabitacion);
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
