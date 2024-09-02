using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasHabitacion : MonoBehaviour
{
    public int vidas = 3;   
    public GameObject vidasHabitacionUI,vida1,vida2,vida3;
    //public CambioDeLugar cambioDeLugar;
    public Hotel hotel;
    public bool skating;

    public PlayerController playerController;
    public Animator anim;
    public ControllerManager controllerManager;
    [SerializeField] private float tiempoPerdidaControl;

    public void Activar()
    {
        vidasHabitacionUI.SetActive(true);
        vidas = 3;
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
    }
    public void Desactivar()
    {
        vidasHabitacionUI.SetActive(false);
    }

    public void Damage(Vector2 posicion)
    {
        vidas -= 1;
        if(vidas == 2)
        {
            vida3.SetActive(false);
            anim.Play("PlayerDamage");
            if (!skating && posicion != null)
            {
                playerController.Rebote(posicion);                
            }
            StartCoroutine(DesactivarColision());
        }
        if(vidas == 1)
        {
            vida2.SetActive(false);
            anim.Play("PlayerDamage");
            if (!skating && posicion != null)
            {
                playerController.Rebote(posicion);              
            }
            StartCoroutine(DesactivarColision());
        }
        if( vidas == 0)
        {
            vida1.SetActive(false);
            if (controllerManager.skating)
            {
                controllerManager.OffSkate(false);
            }
            KillPlayerRoom();
        }
    }
    public void DamageKill(Vector2 posicion)
    {
        vidas -= 2;
        if (vidas == 1)
        {
            vida3.SetActive(false);
            vida2.SetActive(false);
            anim.Play("PlayerDamage");
            if (!skating && posicion != null)
            {
                playerController.Rebote(posicion);
            }
            StartCoroutine(DesactivarColision());
        }
        if (vidas <= 0)
        {
            vida1.SetActive(false);
            //cambioDeLugar.ChangeFloor();
            if (controllerManager.skating)
            {
                controllerManager.OffSkate(false);
            }
            hotel.FadeToBlack();
            Desactivar();
        }
        Invoke("KillPlayerRoom", 2);
    }
    public void DamageInstaKill(Vector2 posicion)
    {
        vidas -= 3;
        if (vidas <= 0)
        {
            vida1.SetActive(false);
            //cambioDeLugar.ChangeFloor();
            if (controllerManager.skating)
            {
                controllerManager.OffSkate(false);
            }
            hotel.FadeToBlack();
            Desactivar();
        }
        Invoke("KillPlayerRoom", 2);
    }
    public void KillPlayerRoom()
    {
        hotel.Piso1(true);
        anim.Play("P_Stan");
        hotel.FadeToBlack();
        Desactivar();
        vidas = 3;
    }

    public void DueloLose()
    {
        anim.Play("P_Dying");
        Invoke("DueloFinal", 2);
    }
    public void DueloWin()
    {
        anim.Play("P_WinPose");       
    }
    void DueloFinal()
    {
        hotel.Piso1(false);
        anim.Play("P_Stan");
        hotel.FadeToBlack();       
    }

    IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(9,10, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
