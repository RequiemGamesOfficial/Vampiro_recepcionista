using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Hotel hotel;
    public GameObject teleportEffect;
    public bool animDestination;
    public Transform destination;
    public bool fade;
    public Animator anim;
    public string animEffect;

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
            if (animDestination)
            {
                destination.SendMessage("PlayAnimation");
            }
            if(teleportEffect != null)
            {
                Instantiate(teleportEffect, destination.position, Quaternion.identity);
                if(anim != null)
                {
                    anim.Play(animEffect);
                }
            }
        }
    }
}
