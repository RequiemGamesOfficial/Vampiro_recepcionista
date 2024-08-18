using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorHabitacionBoss : MonoBehaviour
{
    public bool dead;
    VidasBoss vidasHabitacion;
    public GameObject obetoExtra;

    private void Start()
    {
        vidasHabitacion = GameObject.FindGameObjectWithTag("Player").GetComponent<VidasBoss>();
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

            vidasHabitacion.Activar();
            if (obetoExtra != null)
            {
                obetoExtra.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vidasHabitacion.Desactivar();
            if (obetoExtra != null)
            {
                obetoExtra.SetActive(false);
            }
        }
    }
}
