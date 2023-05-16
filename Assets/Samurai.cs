using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{
    public bool dead;

    private Hotel hotel;
    public Animator anim;

    [SerializeField] HuespedData huespedData;

    public AudioSource audioSource;

    private void Start()
    {
        hotel = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<Hotel>();
    }
    public void RestartDead()
    {
        Debug.Log("RestartDead");
        dead = false;
        anim.SetBool("dead", false);
    }

    public void Attack()
    {
        if (!dead)
        {
            print("Kill");
            audioSource.Play();
            hotel.BeberSangre(huespedData.Blood);
            anim.SetBool("dead", true);
            dead = true;

            hotel.AsesinatoHabitacion();

        }
    }
}
