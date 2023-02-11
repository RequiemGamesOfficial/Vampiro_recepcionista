using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorHabitacion : MonoBehaviour
{
    public GameObject huespedVivo, huespedMuerto;
    public bool dead;
    VidasHabitacion vidasHabitacion;

    private void Start()
    {
        vidasHabitacion = GameObject.FindGameObjectWithTag("Player").GetComponent<VidasHabitacion>();
    }

    //Recibir de hotel si el huesped esta muerto o vivo
    public void HuespedMuerto()
    {
        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            if (dead)
            {
                huespedMuerto.SetActive(true);
            }
            else
            {                
                huespedVivo.SetActive(true);
                huespedVivo.SendMessage("RestartDead");
            }
            vidasHabitacion.Activar();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vidasHabitacion.Desactivar();
            huespedVivo.SetActive(false);
            huespedMuerto.SetActive(false);
        }
    }
}
