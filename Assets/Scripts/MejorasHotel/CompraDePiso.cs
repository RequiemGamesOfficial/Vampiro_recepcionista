using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompraDePiso : MonoBehaviour
{
    bool detected;
    public Hotel hotel;

    public int costo, reputacion, id;
    public GameObject precio;
    public GameObject particlePrefat;
    public GameObject particleStars;

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
            Instantiate(particlePrefat, this.transform.position, Quaternion.identity);
            if (particleStars != null)
            {
                Instantiate(particleStars, this.transform.position, Quaternion.identity);
                Instantiate(particleStars, new Vector3(this.transform.position.x + .8f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Instantiate(particleStars, new Vector3(this.transform.position.x - .8f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            }
            hotel.CompraPiso(costo, reputacion, id);
            Debug.Log("Compra");
            precio.SetActive(false);
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
