using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorHuespeds : MonoBehaviour
{

    [SerializeField] GameObject hombre, mujer, payaso, drogo, padrecito, musico, mago,ciego,marciano,esquimal,astronauta,explorador,tesla,samurai,patineto,naufrago;
    [SerializeField] HuespedData hombreData, mujerData, payasoData, drogoData, padrecitoData, musicoData, magoData,ciegoData, marcianoData, esquimalData, astronautaData,exploradorData, teslaData, samuraiData, patinetoData, naufragoData;
    GameObject huesped01,huesped02,huesped03,huesped04,huesped05,huesped06,huesped07,huesped08;

    int huespedNumber;
    //activa el boton de continuar
    int cantidadDeHuespeds;
    public GameObject gameObjectToEnable;
    [HideInInspector]
    public bool fullHotel;
    bool setPlaya, setJapones;

    //Llamado desde Recepcion
    public void SetPlaya()
    {
        setPlaya = true;
    }
    public void SetJapones()
    {
        setJapones = true;
    }

    //Crea Huespedes depediendo de la reputacion
    public void VIPReputation()
    {
        huesped01 = hombre;
        huesped02 = astronauta;
        huesped03 = patineto;
        huesped04 = tesla;
        huesped05 = astronauta;
        huesped06 = esquimal;
        huesped07 = ciego;
        huesped08 = marciano;
        if (setJapones)
        {
            huesped01 = samurai;
        }
    }
    public void HighReputation()
    {
        huesped01 = hombre;
        huesped02 = astronauta;
        huesped03 = patineto;
        huesped04 = tesla;
        huesped05 = padrecito;
        huesped06 = esquimal;
        huesped07 = ciego;
        huesped08 = marciano;
        if (setJapones)
        {
            huesped01 = samurai;
        }
    }
    public void NormalReputation()
    {
        huesped01 = hombre;
        huesped02 = mujer;
        huesped03 = musico;
        huesped04 = esquimal;
        huesped05 = padrecito;
        huesped06 = tesla;
        huesped07 = ciego;
        huesped08 = explorador;
        if (setJapones)
        {
            huesped01 = samurai;
        }
        if (setPlaya)
        {
            huesped03 = naufrago;
        }
    }
    public void LowReputation()
    {
        huesped01 = drogo;
        huesped02 = mujer;
        huesped03 = payaso;
        huesped04 = patineto;
        huesped05 = marciano;
        huesped06 = mago;
        huesped07 = musico;
        huesped08 = explorador;
        if (setPlaya)
        {
            huesped01 = naufrago;
        }
    }
    public void MediocreReputation()
    {
        huesped01 = drogo;
        huesped02 = mago;
        huesped03 = payaso;
        huesped04 = patineto;
        huesped05 = marciano;
        huesped06 = explorador;
        huesped07 = musico;
        huesped08 = drogo;
        if (setPlaya)
        {
            huesped01 = naufrago;
        }
    }

    public void GenerateNewGuest()
    {
        cantidadDeHuespeds += 1;
        if (cantidadDeHuespeds >= 6)
        {
            gameObjectToEnable.SetActive(true);
            fullHotel = true;
        }
        huespedNumber = Random.Range(1, 9);
        
        if(huespedNumber == 1)
        {
            if (huesped01 != null)
            {
                Instantiate(huesped01,this.transform.position, Quaternion.identity);
            }
        }
        if (huespedNumber == 2)
        {
            if (huesped02 != null)
            {
                Instantiate(huesped02, new Vector2(this.transform.position.x - 1, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 3)
        {
            if (huesped03 != null)
            {
                Instantiate(huesped03, new Vector2(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 4)
        {
            if (huesped04 != null)
            {
                Instantiate(huesped04, new Vector2(this.transform.position.x - 3, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 5)
        {
            if (huesped05 != null)
            {
                Instantiate(huesped05, new Vector2(this.transform.position.x - 4, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 6)
        {
            if (huesped06 != null)
            {
                Instantiate(huesped06, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 7)
        {
            if (huesped07 != null)
            {
                Instantiate(huesped07, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.identity);
            }
        }
        if (huespedNumber == 8)
        {
            if (huesped08 != null)
            {
                Instantiate(huesped08, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.identity);
            }
        }
    }
}
