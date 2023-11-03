using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompraDeHabitacion : MonoBehaviour
{
    bool detected;
    public Hotel hotel;

    public int costo, reputacion,id;
    public GameObject precio, puerta;
    public GameObject particlePrefat;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            QuitarTablas();
        }
    }

    public void QuitarTablas()
    {
        if(hotel.presupuesto >= costo)
        {
            Instantiate(particlePrefat, this.transform.position, Quaternion.identity);
            hotel.AgregarHabitacion(costo, reputacion,id);
            Debug.Log("Compra");
            precio.SetActive(false);
            puerta.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            hotel.NoCashSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            precio.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            precio.SetActive(false);
        }
    }
}
