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

    public GameObject bloodUIPrefab, bloodPrefab;
    Animator contadorUI;
    public CambioDeLugar cambioDeLugar;
    private void Start()
    {
        hotel = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<Hotel>();
        contadorUI = GameObject.FindGameObjectWithTag("Contador").GetComponent<Animator>();
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
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)) && detected)
        {
            Attack();          
        }
    }

    public void Attack()
    {
        if (!dead)
        {
            print("Kill");
            contadorUI.Play("Play");
            Invoke("ChangePlace", 3f);
            audioSource.Play();
            hotel.BeberSangre(huespedData.Blood, huespedData.id);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x + .5f, this.transform.position.y - .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x + 1, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, new Vector3(this.transform.position.x - .5f, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            Instantiate(bloodUIPrefab, this.transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, this.transform.position, Quaternion.identity);
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

    void ChangePlace()
    {
        cambioDeLugar.ChangeFloor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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

    public void LanzarProyectil()
    {
        if (!dead)
        {
            Instantiate(proyectil, this.transform.position, Quaternion.identity);
        }           
    }
}
