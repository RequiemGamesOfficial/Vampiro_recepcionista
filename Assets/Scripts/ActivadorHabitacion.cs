using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorHabitacion : MonoBehaviour
{
    public GameObject huespedVivo, huespedMuerto;
    public bool dead;
    VidasHabitacion vidasHabitacion;
    public GameObject obetoExtra;
    public Canvas canvasWorld;
    public Vector3 newOffsetCamera;
    public CinemachineCameraOffset cameraOffset;


    private void Start()
    {
        vidasHabitacion = GameObject.FindGameObjectWithTag("Player").GetComponent<VidasHabitacion>();
        //Asigna la camara al CanvasWorld de la habitación
        canvasWorld.worldCamera = Camera.main;
        cameraOffset = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineCameraOffset>();
        
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
            if(obetoExtra != null)
            {
                obetoExtra.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraOffset.m_Offset = new Vector3(0, 0, 0);
            vidasHabitacion.Desactivar();
            huespedVivo.SetActive(false);
            huespedMuerto.SetActive(false);
            if (obetoExtra != null)
            {
                obetoExtra.SetActive(false);
            }
        }
    }
}
