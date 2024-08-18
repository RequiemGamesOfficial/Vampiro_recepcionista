using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGuestKitchen : MonoBehaviour
{
    Manager manager;
    public GameObject[] huespedCocina;
    //public GameObject currentGuest;
    public bool active;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        //CheckGuestHunger();
    }

    public void CheckGuestHunger()
    {
        if(manager.checkRoom <= 12)
        {
            //si Habitacion Dead es false y Numero habitacion no es Null
            if (manager.habitacionDead[manager.checkRoom] == false && manager.numeroHabitacion[manager.checkRoom] != null)
            {
                Debug.Log("Id huesped" + manager.numeroHabitacion[manager.checkRoom].id);
                Instantiate(huespedCocina[manager.numeroHabitacion[manager.checkRoom].id], transform.position, Quaternion.identity);
            }
            manager.checkRoom += 1;
        }
    }
}
