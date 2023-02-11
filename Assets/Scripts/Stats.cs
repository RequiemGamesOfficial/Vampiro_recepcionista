using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Manager manager;

    public Slider sliderReputacion, sliderSangre;
    public Text textDinero;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        SetValoresActuales();
    }

    public void SetValoresActuales()
    {
        sliderReputacion.value = manager.reputation;
        sliderSangre.value = manager.blood;
        textDinero.text = ("$" + manager.money);
    }

}
