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

    public GameObject bloodUIPrefab, bloodPrefab;

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
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x + .5f, this.transform.position.y - .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x + 1, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x - .5f, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, this.transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, this.transform.position, Quaternion.identity);
            anim.SetBool("dead", true);
            dead = true;
            button.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !dead)
        {
            detected = true;
            button.SetActive(true);

            //button Android 
            collision.gameObject.GetComponent<DynamicBotton>().UpdateButton(this.gameObject, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            button.SetActive(false);

            //button Android 
            collision.gameObject.GetComponent<DynamicBotton>().ResetButton();
        }
    }
}
