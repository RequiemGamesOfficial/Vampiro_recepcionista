using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotel : MonoBehaviour
{
    Manager manager;
    GameObject player,cameraObject;
    public GameObject pet;

    public GameObject[] puerta = new GameObject[12];
    public GameObject[] habitacionUI = new GameObject[12];
    public GameObject[] tablasH = new GameObject[12];

    public GameObject piso3Construccion, piso3Azotea, piso3, piso3Compra;
    public GameObject piso4Construccion, piso4Azotea, piso4, piso4Compra;
    public GameObject numeroHPiso3, numeroHPiso4;
    public GameObject basura1, basura2, basura3, basura4;
    public GameObject letrero1, letrero2,letrero3;
    public GameObject japones1, japones2,japones3;
    public GameObject playa1,playa2,playa3;

    //public string habitacionActual;
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

    public GameObject posicionHabitacion;
    public GameObject sotanoPrefab;

    public GameObject[] habitacionPrefab = new GameObject[16];

    GameObject habitacionActualGameObject;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        player = GameObject.FindGameObjectWithTag("Player");
        pet = GameObject.FindGameObjectWithTag("Pet");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        textNoche.text = (":" + manager.noche);

        //ActivarPuertas/DesactivarTablas
        for (int i = 4; i < manager.h.Length; i++)
        {
            if (manager.h[i] >= 1)
            {
                tablasH[i].SetActive(false);
                puerta[i].SetActive(true);
            }
        }

        //Desactivar Basura
        if (manager.basura1 >= 1)
        {
            basura1.SetActive(false);
        }
        if (manager.basura2 >= 1)
        {
            basura2.SetActive(false);
            if (manager.japones3 <= 0 && manager.playa3 <= 0)
            {
                letrero3.SetActive(true);
            }
        }
        if (manager.basura3 >= 1)
        {
            basura3.SetActive(false);
            if (manager.japones2 <= 0 && manager.playa2 <= 0)
            {
                letrero2.SetActive(true);
            }
        }
        if (manager.basura4 >= 1)
        {
            basura4.SetActive(false);
            if(manager.japones1<=0 && manager.playa1 <=0)
            {
                letrero1.SetActive(true);
            }
        }
        //Activar Mejoras Hotel
        if (manager.japones1 >= 1)
        {
            japones1.SetActive(true);
        }
        if (manager.japones2 >= 1)
        {
            japones2.SetActive(true);
        }
        if (manager.japones3 >= 1)
        {
            japones3.SetActive(true);
        }
        if (manager.playa1 >= 1)
        {
            playa1.SetActive(true);
        }
        if (manager.playa2 >= 1)
        {
            playa2.SetActive(true);
        }
        if (manager.playa3 >= 1)
        {
            playa3.SetActive(true);
        }
        
        //Activar pisos
        if (manager.piso3 >= 1)
        {
            piso3Compra.SetActive(false);
            if(manager.piso3 >= 2)
            {
                piso3Azotea.SetActive(false);               
                piso3.SetActive(true);
                numeroHPiso3.SetActive(true);
            }
            if (manager.piso3 == 1)
            {
                manager.piso3 += 1;
                piso3Construccion.SetActive(true);
            }
            //Piso4
            piso4Compra.SetActive(true);
            piso4Azotea.SetActive(true);
            if (manager.piso4 >= 1)
            {
                piso4Compra.SetActive(false);
                if (manager.piso4 >= 2)
                {
                    piso4Azotea.SetActive(false);                    
                    piso4.SetActive(true);
                    numeroHPiso4.SetActive(true);
                }
                if (manager.piso4 == 1)
                {
                    manager.piso4 += 1;
                    piso4Construccion.SetActive(true);
                }
            }
        }

        //Array Puertas - Poner Huespedes en habitaciones
        for (int i = 0; i < puerta.Length; i++)
        {
            if (manager.numeroHabitacion[i] != null)
            {
                puerta[i].GetComponent<CambioDeLugar>().nuevoLugar = manager.numeroHabitacion[i].huespedName;
            }
        }        

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
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso1()
    {
        player.transform.position = new Vector3(0, 0f, 0);
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = player.transform.position;
        }
        Debug.Log("BorrarHabitacionCreada");
        if(habitacionActualGameObject != null)
        {
            Destroy(habitacionActualGameObject, 0.5f);
        }
    }
    public void Piso2()
    {
        player.transform.position = new Vector3(0, 6.63f, 0);
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso3()
    {
        player.transform.position = new Vector3(0, 13.292f, 0);
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso4()
    {
        player.transform.position = new Vector3(0, 20.006f, 0);
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = player.transform.position;
        }
    }

    public void TeleportTo(Vector3 place)
    {
        player.transform.position = place;
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = player.transform.position;
        }
    }

    //Checar estado de habitacion Vivo/Muerto llamado desde las habitaciones de los huespedes
    void ChecarEstadoHabitacionYPosicionarJugador(int habitacion)
    {
        activadorHabitacion = habitacionActualGameObject.GetComponentInChildren<ActivadorHabitacion>();

        if (manager.habitacionDead[habitacion])
        {
            activadorHabitacion.SendMessage("HuespedMuerto");
        }

        habitacionActualGameObject.transform.parent = posicionHabitacion.transform;
        player.transform.position = new Vector3(67.75f, 5.4f, 0);
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = player.transform.position;
        }
    }
    //
    public void HabitacionHombre(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[0], posicionHabitacion.transform.position, Quaternion.identity);
        //Decirle al activadorHombre que esta muerto y posicionar jugador
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);       
    }
    public void HabitacionMujer(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[1], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionPayaso(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[2], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionMago(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[3], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionDrogo(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[4], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }  
    public void HabitacionMusico(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[5], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }   
    public void HabitacionCastaway(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[6], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionSamurai(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[7], posicionHabitacion.transform.position, Quaternion.identity); 
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionPadrecito(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[8], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionEskimo(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[9], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionSkater(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[10], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionBlind(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[11], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionAlien(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[12], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionTesla(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[13], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionExplorer(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[14], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionAstronaut(int habitacion)
    {
        habitacionActualGameObject = Instantiate(habitacionPrefab[15], posicionHabitacion.transform.position, Quaternion.identity);
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }

    //Actualizar muertes
    public void AsesinatoHabitacion()
    {
        manager.habitacionDead[habitacionActual] = true;              
    }

    //Checar Habitaciones Para los resultados-Llamado desde TimerHotel al terminar el tiempo
    public void ChecarHaibitaciones()
    {
        manager.habitacionesDisponibles = manager.habitaciones;

        for (int i = 0; i < habitacionUI.Length; i++)
        {
            if (manager.numeroHabitacion[i] != null)
            {
                if (!manager.habitacionDead[i])
                {
                    habitacionUI[i].transform.GetChild(0).GetComponent<Text>().text = manager.numeroHabitacion[i].huespedName;
                    habitacionUI[i].transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.numeroHabitacion[i].money;
                    habitacionUI[i].transform.GetChild(2).GetComponent<Image>().sprite = manager.numeroHabitacion[i].sprite;
                    manager.money += manager.numeroHabitacion[i].money;
                    manager.nightsInRoom[i] -= 1;
                    if (manager.nightsInRoom[i] <= 0)
                    {
                        manager.nightsInRoom[i] = 0;
                    }
                    habitacionUI[i].transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.nightsInRoom[i];
                    if (manager.nightsInRoom[i] >= 1)
                    {
                        manager.habitacionesDisponibles -= 1;
                    }
                }
                else
                {
                    habitacionUI[i].transform.GetChild(0).GetComponent<Text>().text = manager.numeroHabitacion[i].huespedName;
                    habitacionUI[i].transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.numeroHabitacion[i].reputation;
                    habitacionUI[i].transform.GetChild(2).GetComponent<Image>().sprite = manager.numeroHabitacion[i].sprite;
                    manager.reputation += manager.numeroHabitacion[i].reputation;
                    manager.nightsInRoom[i] = 0;
                    habitacionUI[i].transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.nightsInRoom[i];
                }
            }
        }                            

        manager.Guardar();

        //GAME OVER por la reputacion
        if (manager.reputation <= 0)
        {
            changeScene.levelChange = cinematicaPolicia;
        }
    }

    //Mejora del hotel- LLamado desde: CompraMejora/CompraDeHabitacion/CompraPiso
    public void AgregarHabitacion(int costo, int reputacion, int id)
    {
        audioSource.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.habitaciones += 1;
        manager.AgregarHabitacion(id);
        manager.reputation += reputacion;
        stats.SetValoresActuales();
    }
    public void CompraMejora(int costo, int reputacion, int id)
    {
        audioSource.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.MejoraHotel(id);
        manager.reputation += reputacion;
        stats.SetValoresActuales();
    }
    public void CompraPiso(int costo, int reputacion, int id)
    {
        audioSource.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.AgregarPiso(id);
        manager.reputation += reputacion;
        stats.SetValoresActuales();
    }

    public void FadeToBlack()
    {
        animfadeOut.Play("FadeIn");
    }
}
