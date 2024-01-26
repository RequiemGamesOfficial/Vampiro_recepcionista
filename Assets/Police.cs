using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Police : MonoBehaviour
{
    private Hotel hotel;
    public GameObject buttonCosto;
    public TextMeshProUGUI textMeshPro;
    public int costo;
    public int reputation;
    public Canvas canvasWorld;
    bool paid;
    public Animator patrolAnim;
    bool detected;

    private void Start()
    {
        hotel = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<Hotel>();
        canvasWorld.worldCamera = Camera.main;
        textMeshPro.text = "$" + costo;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected && !paid)
        {
            PayBribery();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !paid)
        {
            buttonCosto.SetActive(true);
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonCosto.SetActive(false);
            detected = false;
        }
    }

    public void PayBribery()
    {
        //Mover acciones a Hotel para actualizar stats
        if (costo <= hotel.presupuesto)
        {
            hotel.CompraGeneral(costo, reputation);
            paid = true;
            buttonCosto.SetActive(false);
            patrolAnim.Play("Paid");
        }
        else
        {
            hotel.NoCashSound();
        }
    }
}
