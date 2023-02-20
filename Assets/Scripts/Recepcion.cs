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
    public Image huespedImage;
    public Text textNoche;

    public HuespedData currentHuespedData;
    public GeneradorHuespeds generadorHuespeds;

    int habitacionesDisponibles;

    [Header("TablaHabitaciones")]
    public GameObject llave1;
    public GameObject llave2,llave3,llave4, llave5, llave6, llave7, llave8, llave9, llave10, llave11, llave12;
    public GameObject telaraña1, telaraña2, telaraña3, telaraña4, telaraña5, telaraña6, telaraña7, telaraña8, telaraña9, telaraña10, telaraña11, telaraña12;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        AdministracionLlaves();
        manager.noche += 1;
        //opcional por ahora
        manager.ResetearHabitaciones();
        habitacionesDisponibles = manager.habitaciones;

        textNoche.text = (":"+ manager.noche);

        AsignarReputacion();
        generadorHuespeds.GenerateNewGuest();
        ResetearMuertes();
        //Guardar Juego
        //manager.Guardar();
    }
    public void ResetearMuertes()
    {
        manager.habitacion01Dead = false;
        manager.habitacion02Dead = false;
        manager.habitacion03Dead = false;
        manager.habitacion04Dead = false;
        manager.habitacion05Dead = false;
        manager.habitacion06Dead = false;
        manager.habitacion07Dead = false;
        manager.habitacion08Dead = false;
        manager.habitacion09Dead = false;
        manager.habitacion10Dead = false;
        manager.habitacion11Dead = false;
        manager.habitacion12Dead = false;
    }

    public void AdministracionLlaves()
    {
        if(manager.h4 >= 1)
        {
            llave4.SetActive(true);
            telaraña4.SetActive(false);
        }
        if (manager.h5 >= 1)
        {
            llave5.SetActive(true);
            telaraña5.SetActive(false);
        }
        if (manager.h6 >= 1)
        {
            llave6.SetActive(true);
            telaraña6.SetActive(false);
        }
        if (manager.h7 >= 1)
        {
            llave7.SetActive(true);
            telaraña7.SetActive(false);
        }
        if (manager.h8 >= 1)
        {
            llave8.SetActive(true);
            telaraña8.SetActive(false);
        }
        if (manager.h9 >= 1)
        {
            llave9.SetActive(true);
            telaraña9.SetActive(false);
        }
        if (manager.h10 >= 1)
        {
            llave10.SetActive(true);
            telaraña10.SetActive(false);
        }
        if (manager.h11 >= 1)
        {
            llave11.SetActive(true);
            telaraña11.SetActive(false);
        }
        if (manager.h12 >= 1)
        {
            llave12.SetActive(true);
            telaraña12.SetActive(false);
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
    
    //AgregarHabitaciones
    //public void ActualizarTablaHabitaciones()
    //{
    //    if(manager.habitaciones >= 4)
    //    {
    //        if (manager.habitacion04 != null)
    //        {
    //            llave4.SetActive(false);
    //            telaraña4.SetActive(true);
    //        }
    //    }      
    //}

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
