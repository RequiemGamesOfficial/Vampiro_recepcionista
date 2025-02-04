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
    public GameObject particleStars;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Buying();
        }
    }

    public void Buying()
    {
        if(hotel.presupuesto >= costo)
        {
            Instantiate(particlePrefat, this.transform.position, Quaternion.identity);
            if(particleStars != null)
            {
                Instantiate(particleStars, this.transform.position, Quaternion.identity);
                Instantiate(particleStars, new Vector3(this.transform.position.x + .5f, this.transform.position.y - .5f, this.transform.position.z), Quaternion.identity);
                Instantiate(particleStars, new Vector3(this.transform.position.x - .5f, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            }
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

            //button Android 
            collision.gameObject.GetComponent<DynamicBotton>().UpdateButton(this.gameObject, 2);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            precio.SetActive(false);

            //button Android 
            collision.gameObject.GetComponent<DynamicBotton>().ResetButton();
        }
    }
}
