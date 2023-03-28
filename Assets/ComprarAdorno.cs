using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprarAdorno : MonoBehaviour
{
    public Hotel hotel;

    public int costo, reputacion, id;

    public void Mejorar()
    {
        if (hotel.presupuesto >= costo)
        {
            hotel.CompraMejora(costo, reputacion, id);
            Debug.Log("Compra");
            this.gameObject.SetActive(false);
        }
    }

}
