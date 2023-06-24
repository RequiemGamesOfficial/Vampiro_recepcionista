using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeLugar : MonoBehaviour
{
    bool detected;
    public string nuevoLugar;

    private Hotel hotel;

    public bool habitacion;
    public int numeroHabitacion;

    public AudioSource audioSource;
    public GameObject button;

    ControllerManager controllerManager;

    private void Start()
    {
        hotel = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<Hotel>();
    }

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

        //Habitaciones
        if (nuevoLugar == "Man")
        {
            hotel.HabitacionHombre(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Women")
        {
            hotel.HabitacionMujer(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Clown")
        {
            hotel.HabitacionPayaso(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Priest")
        {
            hotel.HabitacionPadrecito(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Junkie")
        {
            hotel.HabitacionDrogo(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Magician")
        {
            hotel.HabitacionMago(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Musician")
        {
            hotel.HabitacionMusico(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        //
        if (nuevoLugar == "Astronaut")
        {
            hotel.HabitacionAstronaut(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Blind")
        {
            hotel.HabitacionBlind(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Eskimo")
        {
            hotel.HabitacionEskimo(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Explorer")
        {
            hotel.HabitacionExplorer(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Alien")
        {
            hotel.HabitacionAlien(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Castaway")
        {
            hotel.HabitacionCastaway(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Skater")
        {
            hotel.HabitacionSkater(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Samurai")
        {
            hotel.HabitacionSamurai(numeroHabitacion);
            hotel.FadeToBlack();
            audioSource.Play();
            return;
        }
        if (nuevoLugar == "Tesla")
        {
            hotel.HabitacionTesla(numeroHabitacion);
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
