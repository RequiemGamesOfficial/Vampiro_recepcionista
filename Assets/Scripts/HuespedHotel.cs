using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuespedHotel : MonoBehaviour
{
    bool detected;
    public bool dead;

    private Hotel hotel;
    public Animator anim, anim2;

    [SerializeField] HuespedData huespedData;

    public GameObject detector;
    public AudioSource audioSource;
    public GameObject proyectil;
    public GameObject button;

    private void Start()
    {
        hotel = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<Hotel>();
    }
    public void RestartDead()
    {
        Debug.Log("RestartDead");
        dead = false;
        anim.SetBool("dead", false);
        if (anim2 != null)
        {
            anim2.SetBool("dead", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Attack();          
        }
    }

    public void Attack()
    {
        if (!dead)
        {
            print("Kill");
            audioSource.Play();
            hotel.BeberSangre(huespedData.Blood, huespedData.id);
            anim.SetBool("dead", true);
            if (anim2 != null)
            {
                anim2.SetBool("dead", true);
            }
            dead = true;

            hotel.AsesinatoHabitacion();

            //desactivar detector para que jugador no sea cachado
            if (detector != null)
            {
                detector.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            button.SetActive(false);
        }
    }

    public void LanzarProyectil()
    {
        Instantiate(proyectil, this.transform.position, Quaternion.identity);
    }
}
