using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompraDePiso : MonoBehaviour
{
    bool detected;
    public Hotel hotel;

    public int costo, reputacion, id;
    public GameObject precio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Mejorar();
        }
    }

    public void Mejorar()
    {
        if (hotel.presupuesto >= costo)
        {
            hotel.CompraPiso(costo, reputacion, id);
            Debug.Log("Compra");
            precio.SetActive(false);
            this.gameObject.SetActive(false);
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
