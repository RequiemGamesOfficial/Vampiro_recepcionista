using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Hotel hotel;
    public Transform destination;
    public bool fade;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fade)
            {
                hotel.FadeToBlack();
            }            
            hotel.TeleportTo(destination.position);
        }
    }
}
