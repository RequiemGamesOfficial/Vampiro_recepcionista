using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escena1Manager : MonoBehaviour
{
    Manager manager;
    GameObject player, cameraObject;
    public GameObject pet;
    public string habitacionActual;
    public Stats stats;

    public ChangeScene changeScene;

    public Animator animfadeOut;

    //Mejora de hotel
    public int presupuesto;

    public AudioSource audioSource;

    public GameObject posicionHabitacion;

    GameObject habitacionActualGameObject;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        player = GameObject.FindGameObjectWithTag("Player");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        pet = GameObject.FindGameObjectWithTag("Pet");

        //Mejora Hotel
        presupuesto = manager.money;
    }
    public void Piso1()
    {
        player.transform.position = new Vector3(0, 0f, 0);
        cameraObject.transform.position = player.transform.position;
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

    public void BeberSangre(int blood)
    {
        manager.blood += blood;
        stats.SetBlood();
    }

    public void FadeToBlack()
    {
        animfadeOut.Play("FadeIn");
    }
}
