using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscenaInical : MonoBehaviour
{
    Manager manager;
    GameObject player, cameraObject;
    public string habitacionActual;
    ActivadorHabitacion activadorHabitacion;
    public Stats stats;

    public ChangeScene changeScene;
    public string cinematicaPolicia;

    public Animator animfadeOut;

    //Mejora de hotel
    public int presupuesto;

    public AudioSource audioSource;
    public Text textNoche;

    public GameObject posicionHabitacion;
    public GameObject sotanoPrefab;
    public GameObject hHombrePrefab, hMujerPrefab, hPayasoPrefab, hMagoPrefab, hDrogoPrefab, hMusicoPrefab, hNaufragoPrefab, hSamuraiPrefab;
    public GameObject hPadrecitoPrefab, hEsquimalPrefab, hPatinetoPrefab, hCiegoPrefab, hMarcianoPrefab, hTeslaPrefab, hExploradoraPrefab, hAstronautaPrefab;

    GameObject habitacionActualGameObject;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        player = GameObject.FindGameObjectWithTag("Player");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
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
        habitacionActualGameObject = Instantiate(sotanoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        habitacionActualGameObject.transform.parent = posicionHabitacion.transform;
        player.transform.position = new Vector3(67.75f, 5.4f, 0);
        cameraObject.transform.position = player.transform.position;
    }
    public void Piso1()
    {
        player.transform.position = new Vector3(0, 0f, 0);
        Debug.Log("BorrarHabitacionCreada");
        if (habitacionActualGameObject != null)
        {
            Destroy(habitacionActualGameObject, 0.5f);
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
    //Checar estado de habitacion Vivo/Muerto llamado desde las habitaciones de los huespedes
    void ChecarEstadoHabitacionYPosicionarJugador(int habitacion)
    {
        activadorHabitacion = habitacionActualGameObject.GetComponentInChildren<ActivadorHabitacion>();
        if (habitacion <= 6)
        {
            if (habitacion == 1 && manager.habitacion01Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 2 && manager.habitacion02Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 3 && manager.habitacion03Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 4 && manager.habitacion04Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 5 && manager.habitacion05Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 6 && manager.habitacion06Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
        }
        else
        {
            if (habitacion == 7 && manager.habitacion07Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 8 && manager.habitacion08Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 9 && manager.habitacion09Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 10 && manager.habitacion10Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 11 && manager.habitacion11Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
            if (habitacion == 12 && manager.habitacion12Dead)
            {
                activadorHabitacion.SendMessage("HuespedMuerto");
            }
        }
        habitacionActualGameObject.transform.parent = posicionHabitacion.transform;
        player.transform.position = new Vector3(67.75f, 5.4f, 0);
        cameraObject.transform.position = player.transform.position;
    }
    //
    public void HabitacionHombre(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hHombrePrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionMujer(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hMujerPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionPayaso(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hPayasoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionPadrecito(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hPadrecitoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionDrogo(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hDrogoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionMago(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hMagoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionMusico(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hMusicoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    //
    public void HabitacionAstronaut(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hAstronautaPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionBlind(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hCiegoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionEskimo(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hEsquimalPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionExplorer(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hExploradoraPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionAlien(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hMarcianoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionCastaway(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hNaufragoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionSkater(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hPatinetoPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionSamurai(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hSamuraiPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionTesla(int habitacion)
    {
        habitacionActualGameObject = Instantiate(hTeslaPrefab, posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }

    public void FadeToBlack()
    {
        animfadeOut.Play("FadeIn");
    }
}
