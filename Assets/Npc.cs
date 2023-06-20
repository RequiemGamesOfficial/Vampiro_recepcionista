using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public bool dead;

    public GameObject hotel;
    public Animator anim;
    [SerializeField] HuespedData huespedData;
    public AudioSource audioSource;

    public GameObject button;
    bool detected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Attack();
        }
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
            hotel.SendMessage("BeberSangre", huespedData.Blood);
            anim.SetBool("dead", true);
            dead = true;

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
}
