using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Recepcion : MonoBehaviour
{
    public Manager manager;

    public GameObject panelHuesped, yesButton, nextButton, tablaHabitaciones;
    public GameObject huesped;
    public TMP_Text moneyText;
    public TMP_Text nightsText;
    public Image huespedImage;
    public TMP_Text textNoche;

    public HuespedData currentHuespedData;
    public GeneradorHuespeds generadorHuespeds;

    public int habitacionesDisponibles;

    public GameObject[] llave = new GameObject[12];
    public GameObject[] telara�a = new GameObject[12];

    public LogroManager logroManager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.SearchIconSave();
        manager.Guardar();
        if(!manager.demo)
        {
            if (manager.playa1 >= 1 && manager.playa2 >= 1 && manager.playa3 >= 1)
            {
                generadorHuespeds.SetPlaya();
                logroManager.SetUnlockAchievement("CASTAWAY_SET");
            }
            if (manager.japones1 >= 1 && manager.japones2 >= 1 && manager.japones3 >= 1)
            {
                generadorHuespeds.SetJapones();
                logroManager.SetUnlockAchievement("JAPANESE_SET");
            }
        }     
        habitacionesDisponibles = 0;
        manager.noche += 1;
        AchievementPerNight();
        if(manager.noche >= manager.nocheScore)
        {
            manager.nocheScore = manager.noche;
        }

        textNoche.text = (""+ manager.noche);
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

    //Logros por Noches
    public void AchievementPerNight()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        if (manager.noche >= 15)
        {
            logroManager.SetUnlockAchievement("NIGHT_15");
        }
        if (manager.noche >= 30)
        {
            logroManager.SetUnlockAchievement("NIGHT_30");
        }
        if (manager.noche >= 50)
        {
            logroManager.SetUnlockAchievement("NIGHT_50");
        }
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif
    }

    public void AdministracionLlaves()
    {
        for (int i = 0; i < llave.Length; i++)
        {
            if (manager.h[i] >= 1)
            {                
                telara�a[i].SetActive(false);
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
                if (manager.reputation >= 90)
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
