using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetNewGame : MonoBehaviour
{
    public Manager manager;
    public Text textDia;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        textDia.text = ("Dia: " + manager.noche);
    }

    public void ResetearValores()
    {
        Debug.Log("Resetear");
        manager.Restart();
    }


}
