using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasBoss : MonoBehaviour
{
    public int vidas = 3;
    public GameObject vidasHabitacionUI, vida1, vida2, vida3;
    //public CambioDeLugar cambioDeLugar;
    public DemonBoss demonBoss;
    public bool skating;

    public PlayerController playerController;
    public Animator anim;
    public ControllerManager controllerManager;
    [SerializeField] private float tiempoPerdidaControl;
    public bool dead;

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
        if (!dead)
        {
            vidas -= 1;
            if (vidas == 2)
            {
                vida3.SetActive(false);
                anim.Play("PlayerDamage");
                if (!skating && posicion != null)
                {
                    playerController.Rebote(posicion);
                }
                StartCoroutine(DesactivarColision());
            }
            if (vidas == 1)
            {
                vida2.SetActive(false);
                anim.Play("PlayerDamage");
                if (!skating && posicion != null)
                {
                    playerController.Rebote(posicion);
                }
                StartCoroutine(DesactivarColision());
            }
            if (vidas == 0)
            {
                vida1.SetActive(false);
                KillPlayerRoom();
            }
        }     
    }

    public void KillPlayerRoom()
    {
        if (!dead)
        {
            Debug.Log("KillPlayer-VidasBoss");
            dead = true;
            Desactivar();
            if (controllerManager.skating)
            {
                controllerManager.OffSkate(false);
            }
            demonBoss.PlayerDead();
        }
    }

    IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
