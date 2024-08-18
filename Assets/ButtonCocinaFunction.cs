using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCocinaFunction : MonoBehaviour
{
    public GenerateGuestKitchen generateGuestKitchen;
    public GenerateBurger generateBurger;
    public RecibidorCocina recibidorCocina;
    public GameObject buttonIniciar,buttonCocina;

    public bool waiting;

    public void ButtonIniciar()
    {
        if (!waiting)
        {
            generateGuestKitchen.CheckGuestHunger();
            generateBurger.ActiveGenerate(true);
            buttonIniciar.SetActive(false);
            waiting = true;
        }
    }

    public void ButtonCocina()
    {
        recibidorCocina.EntregaComidaManager();
        buttonCocina.SetActive(false);
    }

    //Desactivar y activar
    public void ActivarBIniciar()
    {
        buttonIniciar.SetActive(true);
        buttonCocina.SetActive(false);
    }
    public void ActivarBCocina()
    {
        buttonIniciar.SetActive(false);
        buttonCocina.SetActive(true);
    }
    public void DesactivarButtons()
    {
        buttonIniciar.SetActive(false);
        buttonCocina.SetActive(false);
    }
}
