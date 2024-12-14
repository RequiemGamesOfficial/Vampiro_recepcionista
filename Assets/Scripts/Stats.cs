using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    GameObject managerObject;
    SteamAchievement steamAchievement;
    public Manager manager;

    public Slider sliderReputacion, sliderReputacionNew, sliderSangre, sliderSangreNew;
    public Text textMoney;
    float newMoney, currentMoney,currentReputation;
    float timer;
    float limitTimer;
    public float timerLimit = 20;

    bool bloodDown, bloodUP,newBloodDown,newBloodUP;
    bool moneyDown, moneyUp;
    bool reputationDown, reputationUP;

    private void Awake()
    {
        managerObject = GameObject.FindGameObjectWithTag("Manager");
        steamAchievement = managerObject.GetComponent<SteamAchievement>();
        manager = managerObject.GetComponent<Manager>();
        SetValoresActuales();
    }

    private void Update()
    {
        //Cambio de Sangre Perdida y ganancia
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
                bloodDown = false;
            }
        }

        if (newBloodUP)
        {
            sliderSangreNew.value += 5 * Time.deltaTime;
            if (sliderSangreNew.value >= sliderSangre.value)
            {
                sliderSangreNew.value = sliderSangre.value;
                newBloodUP = false;
            }
        }
        if (newBloodDown)
        {
            sliderSangreNew.value -= 5 * Time.deltaTime;
            if (sliderSangreNew.value <= sliderSangre.value)
            {
                sliderSangreNew.value = sliderSangre.value;
                newBloodDown = false;
            }
        }

        //Cambio de dinero 
        if (moneyUp)
        {
            currentMoney += 1;
            limitTimer += 1;
            textMoney.text = ("$" + currentMoney);

            if (currentMoney >= newMoney || limitTimer >= timerLimit)
            {
                currentMoney = newMoney;
                textMoney.text = ("$" + currentMoney);
                limitTimer = 0;
                moneyUp = false;
            }
        }
        if (moneyDown)
        {
            currentMoney -= 1;
            limitTimer += 1;
            textMoney.text = ("$" + currentMoney);
            if (currentMoney <= newMoney || limitTimer >= timerLimit)
            {
                currentMoney = newMoney;
                textMoney.text = ("$" + currentMoney);
                limitTimer = 0;
                moneyDown = false;
            }
        }

        //Cambio de Reputación 
        if (reputationDown)
        {
            sliderReputacionNew.value -= 5 * Time.deltaTime;
            if (sliderReputacionNew.value <= sliderReputacion.value)
            {
                sliderReputacion.value = manager.reputation;
                sliderReputacionNew.value = manager.reputation;
                reputationDown = false;
            }
        }
        if (reputationUP)
        {
            sliderReputacion.value += 5 * Time.deltaTime;
            if (sliderReputacion.value >= sliderReputacionNew.value)
            {
                sliderReputacion.value = manager.reputation;
                sliderReputacionNew.value = manager.reputation;
                reputationUP = false;
            }
        }
    }

    private void LateUpdate()
    {

    }
    public void SetValoresActuales()
    {
        sliderReputacion.value = manager.reputation;
        sliderReputacionNew.value = manager.reputation;
        sliderSangre.value = manager.blood;
        sliderSangreNew.value = manager.blood;
        currentMoney = manager.money;
        currentReputation = manager.reputation;
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
    //Quitar Sangre
    public void SetNewBlood()
    {
        sliderSangre.value = manager.blood;
        Invoke("ChangeNewBlood", 1f);
    }
    public void ChangeNewBlood()
    {
        if (sliderSangreNew.value < sliderSangre.value)
        {
            newBloodUP = true;
        }
        if (sliderSangreNew.value > sliderSangre.value)
        {
            newBloodDown = true;
        }
    }
    //Modificar Reputacion
    public void SetReputation()
    {
        if(currentReputation < manager.reputation)
        {
            SetReputationUp();
        }
        else
        {
            SetReputationDown();
        }

        if(manager.reputation >= 100)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            // Steam logros
            steamAchievement.UnlockAchievement("5_STARS");
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif
        }
        currentReputation = manager.reputation;
    }
    void SetReputationUp()
    {
        sliderReputacionNew.value = manager.reputation;
        reputationUP = true;
    }
    void SetReputationDown()
    {
        sliderReputacion.value = manager.reputation;
        reputationDown = true;       
    }
}
