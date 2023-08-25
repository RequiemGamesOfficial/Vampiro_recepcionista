using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DueloScript : MonoBehaviour
{
    public Canvas canvasWorld;
    public GameObject buttonSombra,buttonAttack;

    GameObject player;
    bool duelo;
    public float timeToWin;
    public float dueloTimer;  

    Animator animDuelo;
    public Animator animSamurai;
    public EventsTriggers eventsTriggers;

    private void Start()
    {        
        canvasWorld.worldCamera = Camera.main;
        animDuelo = GetComponent<Animator>();
        eventsTriggers = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<EventsTriggers>();
        animSamurai.Play("PreAttack");
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
            player.SendMessage("FalseMove");
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
        eventsTriggers.TriggerDuelo();
        //Iniciar animacion duelo
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
        animDuelo.Play("TerminarDuelo");
        animSamurai.Play("Attack");
        duelo = false;
        buttonAttack.SetActive(false);
        buttonSombra.SetActive(false);
        Debug.Log(dueloTimer);
        PararCoroutine();
        if(dueloTimer < timeToWin)
        {
            animDuelo.SetBool("VampireWin", true);
            animSamurai.SetBool("dead", true);
        }
        else
        {
            animDuelo.SetBool("VampireWin", false);
        }
    }

    public void VampireWin()
    {
        animSamurai.SetBool("dead", true);
        player.SendMessage("TrueMove");
        eventsTriggers.ResetFollowCameraToPlayer();
    }

    public void VampireLose()
    {
        player.SendMessage("DueloLose");
        eventsTriggers.ResetFollowCameraToPlayer();
    }

    void PararCoroutine()
    {
        StopAllCoroutines();
    }

}
