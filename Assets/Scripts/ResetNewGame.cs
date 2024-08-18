using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetNewGame : MonoBehaviour
{
    public Manager manager;
    public Text textNoche;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        textNoche.text = (""+manager.noche);
    }

    public void ResetearValores()
    {
        Debug.Log("Resetear");
        manager.Restart();
    }


}
