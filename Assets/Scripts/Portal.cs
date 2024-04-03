using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Hotel hotel;
    public GameObject teleportEffect;
    public Transform destination;
    public bool fade;

    private void Start()
    {
        hotel = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<Hotel>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fade)
            {
                hotel.FadeToBlack();
            }            
            hotel.TeleportTo(destination.position);
            if(teleportEffect != null)
            {
                Instantiate(teleportEffect, destination.position, Quaternion.identity);
            }
        }
    }
}
