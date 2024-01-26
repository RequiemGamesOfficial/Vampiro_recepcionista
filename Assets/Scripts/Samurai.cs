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
    public GameObject bloodUIPrefab, bloodPrefab;

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
            hotel.BeberSangre(huespedData.Blood,huespedData.id);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x + .5f, this.transform.position.y - .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x + 1, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x - .5f, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, this.transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, this.transform.position, Quaternion.identity);
            anim.SetBool("dead", true);
            dead = true;

            hotel.AsesinatoHabitacion();

        }
    }
}
