using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPanel : MonoBehaviour
{
    Manager manager;
    public Stats stats;

    public Transform block1, block2, block3;
    public List<int> excludedNumbers = new List<int> { 0, 1, 3, 5, 7, 16 };
    public GameObject[] accidentBlock;
    public int random1, random2, random3;
    //public bool accidentActive1, accidentActive2, accidentActive3;
    public AudioSource audioSource;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        SetAccidentsByGuest();
    }

    //Old
    //public void SetAccidentsBlocks()
    //{
    //    //Block1
    //    random1 = Random.Range(0, accidentBlock.Length);
    //    if(!excludedNumbers.Contains(random1))
    //    {           
    //        if (accidentBlock[random1] != null)
    //        {
    //            accidentBlock[random1].transform.position = block1.transform.position;
    //            accidentBlock[random1].SetActive(true);
    //        }
    //        //Block2
    //        random2 = Random.Range(0, accidentBlock.Length);
    //        if (!excludedNumbers.Contains(random2) && random2 != random1)
    //        {
    //            if (accidentBlock[random2] != null)
    //            {
    //                accidentBlock[random2].transform.position = block2.transform.position;
    //                accidentBlock[random2].SetActive(true);
    //            }
    //            //Block3
    //            random3 = Random.Range(0, accidentBlock.Length);
    //            if (!excludedNumbers.Contains(random3) && random3 != random2 && random3!= random1)
    //            {
    //                if (accidentBlock[random3] != null)
    //                {
    //                    accidentBlock[random3].transform.position = block3.transform.position;
    //                    accidentBlock[random3].SetActive(true);
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("No hay accidentes");
    //    }
    //}


    public void SetAccidentsByGuest()
    {
        //Block1
        random1 = Random.Range(0, manager.habitaciones+1);
        //si Habitacion Dead es false y Numero habitacion no es Null
        if (manager.habitacionDead[random1] == false && manager.numeroHabitacion[random1] != null)
        {
            int id1 = manager.numeroHabitacion[random1].id;
            //Checar que el id del evento si puede ocurrir, por pruebas o por no estar diseñado
            if (!excludedNumbers.Contains(id1))
            {
                Debug.Log("accident in " + random1 + "Of guest " + id1);
                accidentBlock[id1].SetActive(true);
                accidentBlock[id1].SendMessage("SetAccidentID", 1);
                accidentBlock[id1].transform.position = block1.transform.position;
                manager.accident1 = id1;
            }          
        }
        //Block2
        random2 = Random.Range(0, manager.habitaciones+1);
        //si Habitacion Dead es false y Numero habitacion no es Null
        if (manager.habitacionDead[random2] == false && manager.numeroHabitacion[random2] != null)
        {
            int id2 = manager.numeroHabitacion[random2].id;
            //Checar que el id del evento si puede ocurrir, por pruebas o por no estar diseñado
            if (!excludedNumbers.Contains(id2))
            {
                Debug.Log("accident in " + random2 + "Of guest " + id2);
                accidentBlock[id2].SetActive(true);
                accidentBlock[id2].SendMessage("SetAccidentID", 2);
                accidentBlock[id2].transform.position = block2.transform.position;
                manager.accident2 = id2;
            }
        }
        //Block2
        random3 = Random.Range(0, manager.habitaciones+1);
        //si Habitacion Dead es false y Numero habitacion no es Null
        if (manager.habitacionDead[random3] == false && manager.numeroHabitacion[random3] != null)
        {
            int id3 = manager.numeroHabitacion[random3].id;
            //Checar que el id del evento si puede ocurrir, por pruebas o por no estar diseñado
            if (!excludedNumbers.Contains(id3))
            {
                Debug.Log("accident in " + random3 + "Of guest " + id3);
                accidentBlock[id3].SetActive(true);
                accidentBlock[id3].SendMessage("SetAccidentID", 3);
                accidentBlock[id3].transform.position = block3.transform.position;
                manager.accident3 = id3;
            }
        }
    }

    public void PayAccident(int id, int money,int reputation)
    {
        if(id == 1)
        {
            manager.accident1 = 0;
        }
        if (id == 2)
        {
            manager.accident2 = 0;
        }
        if (id == 3)
        {
            manager.accident3 = 0;
        }
        audioSource.Play();
        manager.money -= money;
        manager.reputation += reputation;
        stats.SetMoney();
        stats.SetReputation();
    }
}
