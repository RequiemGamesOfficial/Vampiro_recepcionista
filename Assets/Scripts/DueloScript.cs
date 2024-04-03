using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DueloScript : MonoBehaviour
{
    public Canvas canvasWorld;
    public GameObject buttonSombra,buttonAttack;
    public bool android;
    public GameObject buttonsAndroid;

    GameObject player;
    bool duelo;
    public float timeToWin;
    public float dueloTimer;  

    Animator animDuelo;
    public Animator animSamurai;
    public Samurai samurai;
    public EventsTriggers eventsTriggers;
    AudioSource audioSource;
    public AudioClip vampireWin, vampireLose;
    public GameObject newTarget;

    private void Start()
    {        
        canvasWorld.worldCamera = Camera.main;
        animDuelo = GetComponent<Animator>();
        eventsTriggers = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<EventsTriggers>();
        animSamurai.Play("PreAttack");
        audioSource = GetComponent<AudioSource>();
        if (android)
        {
            buttonsAndroid = GameObject.FindGameObjectWithTag("ButtonsAndroid");
        }
    }

    private void Update()
    {
        if (duelo)
        {
            dueloTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.SendMessage("FalseMoveSamurai");
            StartCoroutine(DuetoStart());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SendMessage("TrueMove");
        }
    }

    IEnumerator DuetoStart()
    {
        yield return new WaitForSeconds(1);
        //Cambiar follow de camera
        eventsTriggers.TriggerDuelo(newTarget);
        //Iniciar animacion duelo
        if (android)
        {
            buttonsAndroid.SetActive(false);
        }
        buttonSombra.SetActive(true);
        animDuelo.Play("Duelo");
        yield return new WaitForSeconds(3);
        //Poner boton de duelo
        duelo = true;
        buttonAttack.SetActive(true);        
        yield return new WaitForSeconds(4f);
        //Terminar duelo si aun no presiona boton
        TerminarDuelo();        
    }

    public void TerminarDuelo()
    {
        player.SendMessage("Attack");
        animDuelo.Play("TerminarDuelo");
        animSamurai.Play("Attack");
        duelo = false;
        if (android)
        {
            buttonsAndroid.SetActive(true);
        }
        buttonAttack.SetActive(false);
        buttonSombra.SetActive(false);
        Debug.Log(dueloTimer);
        PararCoroutine();
        if(dueloTimer < timeToWin)
        {
            animDuelo.SetBool("VampireWin", true);
        }
        else
        {
            animDuelo.SetBool("VampireWin", false);
        }
    }

    //Llamados desde la animacion del duelo
    public void VampireWin()
    {
        //Obtener sangre del Samurai
        audioSource.clip = vampireWin;
        audioSource.Play();
        samurai.Attack();
        animSamurai.SetBool("dead", true);
        player.SendMessage("DueloWin");
        eventsTriggers.ResetFollowCameraToPlayer();
        dueloTimer = 0;
    }

    public void VampireLose()
    {
        audioSource.clip = vampireLose;
        audioSource.Play();
        player.SendMessage("DueloLose");
        eventsTriggers.ResetFollowCameraToPlayer();
        dueloTimer = 0;
    }

    void PararCoroutine()
    {
        StopAllCoroutines();
    }

}
