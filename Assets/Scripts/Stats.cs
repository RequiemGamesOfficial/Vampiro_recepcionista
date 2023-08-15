using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Manager manager;

    public Slider sliderReputacion, sliderSangre, sliderSangreNew;
    public Text textMoney;
    float newMoney, currentMoney;
    float timer;

    bool bloodDown, bloodUP;
    public bool moneyDown, moneyUp;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        SetValoresActuales();
    }

    private void Update()
    {
        if (bloodUP)
        {
            sliderSangre.value += 5 * Time.deltaTime;
            if(sliderSangre.value >= sliderSangreNew.value)
            {
                sliderSangre.value = sliderSangreNew.value;
                bloodUP = false;
            }
        }
        if (bloodDown)
        {
            sliderSangre.value -= 5 * Time.deltaTime;
            if (sliderSangre.value <= sliderSangreNew.value)
            {
                sliderSangre.value = sliderSangreNew.value;
                bloodUP = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (moneyUp)
        {
            currentMoney += 1;
            textMoney.text = ("$" + currentMoney);
            if (currentMoney >= newMoney)
            {
                currentMoney = newMoney;
                textMoney.text = ("$" + currentMoney);
                moneyUp = false;
            }
        }
        if (moneyDown)
        {
            currentMoney -= 1;
            textMoney.text = ("$" + currentMoney);
            if (currentMoney <= newMoney)
            {
                currentMoney = newMoney;
                textMoney.text = ("$" + currentMoney);
                moneyUp = false;
            }
        }
    }
    public void SetValoresActuales()
    {
        sliderReputacion.value = manager.reputation;
        sliderSangre.value = manager.blood;
        sliderSangreNew.value = manager.blood;
        currentMoney = manager.money;
        textMoney.text = ("$" + currentMoney);
    }

    public void SetMoney()
    {
        newMoney = manager.money;
        if(currentMoney < newMoney)
        {
            moneyUp = true;
        }
        if (currentMoney > newMoney)
        {
            moneyDown = true;
        }
    }
    //Establece el cambio de cantidad de la sangre, llamado cuando el vampiro obtiene o pierde sangre
    public void SetBlood()
    {
        sliderSangreNew.value = manager.blood;
        Invoke("ChangeBlood", .5f);       
    }
    //Detecta si el valor es mayor o menor para indicarle en update si se sube o si se baja
    public void ChangeBlood()
    {
        if (sliderSangre.value < sliderSangreNew.value)
        {
            bloodUP = true;
        }
        if (sliderSangre.value > sliderSangreNew.value)
        {
            bloodDown = true;
        }
    }
}
