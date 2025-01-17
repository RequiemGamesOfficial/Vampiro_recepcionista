using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Police : MonoBehaviour
{
    SteamAchievement steamAchievement;

    private Hotel hotel;
    public GameObject buttonCosto;
    public TextMeshProUGUI textMeshPro;
    public int costo;
    public int reputation;
    public Canvas canvasWorld;
    bool paid;
    public Animator patrolAnim;
    bool detected;
    public GameObject particleStars;

    private void Start()
    {
        steamAchievement = GameObject.FindGameObjectWithTag("Manager").GetComponent<SteamAchievement>();
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
#if UNITY_STANDALONE || UNITY_EDITOR
            // Steam logros
            steamAchievement.UnlockAchievement("BRIBING_COP");
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif
            hotel.CompraGeneral(costo, reputation);
            paid = true;
            buttonCosto.SetActive(false);
            patrolAnim.Play("Paid");
            if (particleStars != null)
            {
                Instantiate(particleStars, this.transform.position, Quaternion.identity);
                Instantiate(particleStars, new Vector3(this.transform.position.x + .8f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Instantiate(particleStars, new Vector3(this.transform.position.x - .8f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            }
        }
        else
        {
            hotel.NoCashSound();
        }
    }
}
