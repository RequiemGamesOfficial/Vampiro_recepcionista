using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorHuespeds : MonoBehaviour
{

    [SerializeField] GameObject hombre, mujer, payaso, drogo, padrecito, musico,mago;
    [SerializeField] HuespedData hombreData, mujerData, payasoData, drogoData, padrecitoData, musicoData, magoData;
    GameObject huesped01,huesped02,huesped03,huesped04,huesped05,huesped06;

    int huespedNumber;
    //activa el boton de continuar
    int cantidadDeHuespeds;
    public GameObject gameObjectToEnable;
    [HideInInspector]
    public bool fullHotel;
    //Crea Huespedes depediendo de la reputacion
    public void VIPReputation()
    {
        huesped01 = hombre;
        huesped02 = mujer;
        huesped03 = payaso;
        huesped04 = drogo;
        huesped05 = padrecito;
        huesped06 = musico;
    }
    public void HighReputation()
    {
        huesped01 = hombre;
        huesped02 = mujer;
        huesped03 = payaso;
        huesped04 = drogo;
        huesped05 = padrecito;
        huesped06 = musico;
    }
    public void NormalReputation()
    {
        huesped01 = hombre;
        huesped02 = mujer;
        huesped03 = payaso;
        huesped04 = drogo;
        huesped05 = padrecito;
        huesped06 = musico;
    }
    public void LowReputation()
    {
        huesped01 = hombre;
        huesped02 = mujer;
        huesped03 = payaso;
        huesped04 = drogo;
        huesped05 = padrecito;
        huesped06 = musico;
    }
    public void MediocreReputation()
    {
        huesped01 = hombre;
        huesped02 = mujer;
        huesped03 = payaso;
        huesped04 = drogo;
        huesped05 = padrecito;
        huesped06 = musico;
    }

    public void GenerateNewGuest()
    {
        cantidadDeHuespeds += 1;
        if (cantidadDeHuespeds >= 6)
        {
            gameObjectToEnable.SetActive(true);
            fullHotel = true;
        }
        huespedNumber = Random.Range(1, 7);
        
        if(huespedNumber == 1)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped01,this.transform.position, Quaternion.identity);
            }
        }
        if (huespedNumber == 2)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped02, new Vector2(this.transform.position.x - 1, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 3)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped03, new Vector2(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 4)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped04, new Vector2(this.transform.position.x - 3, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 5)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped05, new Vector2(this.transform.position.x - 4, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 6)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped06, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.identity);
            }
        }
    }
}
