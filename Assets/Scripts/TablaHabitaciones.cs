using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaHabitaciones : MonoBehaviour
{

    public Recepcion recepcion;
    
    //Llamado desde los botones de llaves
    public void LLaveHabitacion(int habitacion)
    {
        recepcion.AsignarHabitacion(habitacion);
        recepcion.llave[habitacion].SetActive(false);
        this.gameObject.SetActive(false);
    }
    
}
