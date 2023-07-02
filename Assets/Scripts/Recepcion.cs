using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recepcion : MonoBehaviour
{
    public Manager manager;

    public GameObject panelHuesped, yesButton, nextButton, tablaHabitaciones;
    public GameObject huesped;
    public Text huespedText;
    public Text moneyText;
    public Text nightsText;
    public Image huespedImage;
    public Text textNoche;

    public HuespedData currentHuespedData;
    public GeneradorHuespeds generadorHuespeds;

    public int habitacionesDisponibles;

    public GameObject[] llave = new GameObject[12];
    public GameObject[] telaraña = new GameObject[12];

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        habitacionesDisponibles = 0;
        manager.noche += 1;

        textNoche.text = (":"+ manager.noche);
        AdministracionLlaves();
        AsignarReputacion();
        generadorHuespeds.GenerateNewGuest();
        ResetearMuertes();
    }
    public void ResetearMuertes()
    {
        for (int i = 0; i < manager.habitacionDead.Length; i++)
        {
            manager.habitacionDead[i] = false;
        }              
    }

    public void AdministracionLlaves()
    {
        for (int i = 0; i < llave.Length; i++)
        {
            if (manager.h[i] >= 1)
            {                
                telaraña[i].SetActive(false);
                if (manager.nightsInRoom[i] <= 0)
                {
                    Debug.Log("HabitacionDisponible");
                    habitacionesDisponibles += 1;
                    llave[i].SetActive(true);                   
                }
            }
        }        
    }
    public void AsignarReputacion()
    {
        if (manager.reputation <= 20)
        {
            generadorHuespeds.MediocreReputation();
            return;
        }
        else
        {
            if (manager.reputation <= 44 && manager.reputation >= 21)
            {
                generadorHuespeds.LowReputation();
                return;
            }
            else
            {
                if (manager.reputation <= 64 && manager.reputation >= 45)
                {
                    generadorHuespeds.NormalReputation();
                    return;
                }
                if (manager.reputation <= 89 && manager.reputation >= 65)
                {
                    generadorHuespeds.HighReputation();
                    return;
                }
                if (manager.reputation > 90)
                {
                    generadorHuespeds.VIPReputation();
                    return;
                }
            }          
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Huesped"))
        {
            collision.SendMessage("RecibirHuesped");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Huesped"))
        {
            print("Nohuesped");
        }
    }

    public void AtencionAlHuesped(GameObject huespedObject, HuespedData huespedData)
    {
        currentHuespedData = huespedData;
        huesped = huespedObject;
        huespedText.text = huespedData.huespedName;
        moneyText.text = ("$" + huespedData.money);
        int randomNumber = Random.Range(1, 4);
        huespedData.nights = randomNumber;
        nightsText.text = ("" + huespedData.nights);
        huespedImage.sprite = huespedData.sprite;
        panelHuesped.SetActive(true);
        if(habitacionesDisponibles <= 0)
        {
            yesButton.SetActive(false);
        }
    }

    public void AnswerYes()
    {
        panelHuesped.SetActive(false);
        //Borrar huespedname
        tablaHabitaciones.SetActive(true);
    }

    public void AsignarHabitacion(int habitacion)
    {
        manager.AgregarHuespedEnHabitacionEspecifica(currentHuespedData,habitacion);
        huesped.SendMessage("ReceptionYes");
        habitacionesDisponibles -= 1;
        if (habitacionesDisponibles <= 0)
        {
            nextButton.SetActive(true);
        }
        if (!generadorHuespeds.fullHotel)
        {
            generadorHuespeds.GenerateNewGuest();
        }
    }
    public void AnswerNo()
    {
        panelHuesped.SetActive(false);
        huesped.SendMessage("ReceptionNo");
        if (!generadorHuespeds.fullHotel)
        {
            generadorHuespeds.GenerateNewGuest();
        }      
    }
}
