using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscenaInical : MonoBehaviour
{
    Manager manager;
    GameObject player, cameraObject;
    public GameObject pet;
    public int habitacionActual;
    ActivadorHabitacion activadorHabitacion;
    public Stats stats;

    public ChangeScene changeScene;
    public string cinematicaPolicia;
    public Animator animfadeOut;

    //Mejora de hotel
    public int presupuesto;
    public AudioSource audioSource;
    public Text textNoche;
    GameObject habitacionActualGameObject;

    //Fase2
    public bool fase2;
    public BoxCollider2D doorCollider;
    public BoxCollider2D triggerContinuar;

    public AudioSource audioSourceCompra, noCashSound;
    public int habitaciones;
    public GameObject continuarObject,tutorialDiablo;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        player = GameObject.FindGameObjectWithTag("Player");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        pet = GameObject.FindGameObjectWithTag("Pet");
        textNoche.text = (":" + manager.noche);

        //Mejora Hotel
        presupuesto = manager.money;
    }
    public void BeberSangre(int blood)
    {
        manager.blood += blood;
        stats.SetValoresActuales();
    }

    //habitaciones Cambio de lugar del jugador y la camara A HABITACION CORRESPONDIENTE
    public void Sotano()
    {
        player.transform.position = new Vector3(67.75f, 5.4f, 0);
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso1()
    {
        player.transform.position = new Vector3(0, 0f, 0);
        Debug.Log("BorrarHabitacionCreada");
        if (habitacionActualGameObject != null)
        {
            Destroy(habitacionActualGameObject, 0.5f);
        }
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso2()
    {
        player.transform.position = new Vector3(0, 6.63f, 0);
    }
    public void Piso3()
    {
        player.transform.position = new Vector3(0, 13.292f, 0);
    }
    public void Piso4()
    {
        player.transform.position = new Vector3(0, 20.006f, 0);
    }

    public void TeleportTo(Vector3 place)
    {
        player.transform.position = place;
    }   

    public void TriggerFase()
    {
        fase2 = true;
        doorCollider.enabled = false;
        triggerContinuar.enabled = true;
    }

    public void FadeToBlack()
    {
        animfadeOut.Play("FadeIn");
    }

    public void AgregarHabitacion(int costo)
    {
        audioSourceCompra.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        stats.SetMoney();
        habitaciones += 1;
        if(habitaciones >= 3)
        {
            continuarObject.SetActive(true);
            tutorialDiablo.SetActive(false);
        }
    }

    public void NoCashSound()
    {
        noCashSound.Play();
    }
}
