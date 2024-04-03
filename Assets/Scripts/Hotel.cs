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
    public GameObject[] moneyIcon = new GameObject[12];
    public GameObject[] reputationIcon = new GameObject[12];
    public Image[] iconGuest = new Image[12];
    public GameObject moneyParticle;

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

    public Animator animfadeOut;

    //Mejora de hotel
    public int presupuesto;

    public AudioSource audioSourceCompra, musica,noCashSound;
    public AudioClip [] musicaHabitacion = new AudioClip[17];
    public Text textNoche;

    public GameObject posicionHabitacion;
    public GameObject sotanoPrefab;

    public GameObject[] habitacionPrefab = new GameObject[16];

    GameObject habitacionActualGameObject;
    Vector3 playerPosAnterior;
    public GameObject patrulla;
    public GameObject tutorialReputacion,tutorialDiablo,tutorialResultados;
    public GameObject tutorialActual, tutorialReputacionActual;
    public TimerHotel timerHotel;
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        if (manager.noche == 1)
        {
            tutorialReputacionActual = Instantiate(tutorialReputacion);
            //timerHotel.limitTime = 30;
        }
        else
        {
            Destroy(tutorialResultados);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        pet = GameObject.FindGameObjectWithTag("Pet");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Start()
    {
        textNoche.text = ("" + manager.noche);

        //ActivarPuertas/DesactivarTablas
        for (int i = 3; i < manager.h.Length; i++)
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
        else
        {
            if (manager.playa1 >= 1)
            {
                playa1.SetActive(true);
            }
        }
        if (manager.japones2 >= 1)
        {
            japones2.SetActive(true);
        }
        else
        {
            if (manager.playa2 >= 1)
            {
                playa2.SetActive(true);
            }
        }
        if (manager.japones3 >= 1)
        {
            japones3.SetActive(true);
        }
        else
        {
            if (manager.playa3 >= 1)
            {
                playa3.SetActive(true);
            }
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

        //Iconos de Huespedes
        for (int i = 0; i < iconGuest.Length; i++)
        {
            if (manager.numeroHabitacion[i] != null)
            {
                iconGuest[i].sprite = manager.numeroHabitacion[i].sprite;
            }
        }

        //Activar Patrulla
        if(manager.reputation <= 20)
        {
            Instantiate(patrulla);
        }
    }
    public void BeberSangre(int blood, int id)
    {
        manager.blood += blood;
        stats.SetBlood();
        manager.HuespedDead(id);
    }

    //Guardar Posicion de jugador para luego ponerlo donde estaba
    public void AsignarPoscicionDeJugador()
    {
        playerPosAnterior = player.transform.position;
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

    public void Piso1(bool posAnterior = false)
    {
        if(musica.clip != musicaHabitacion[16])
        {
            musica.clip = musicaHabitacion[16];
            musica.Play();
        }
        if (posAnterior)
        {
            player.transform.position = playerPosAnterior;
        }
        else
        {
            player.transform.position = new Vector3(0, 0f, 0);
        }      
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

        //Tutorial
        if (manager.noche == 1 && tutorialActual == null)
        {
            Debug.Log("Reputacion Diablo");
            tutorialActual = Instantiate(tutorialDiablo);
            Destroy(tutorialReputacionActual);
        }
    }
    public void Piso2(bool posAnterior = false)
    {
        if (musica.clip != musicaHabitacion[16])
        {
            musica.clip = musicaHabitacion[16];
            musica.Play();
        }
        if (posAnterior)
        {
            player.transform.position = playerPosAnterior;
        }
        else
        {
            player.transform.position = new Vector3(0, 7.86f, 0);
        }        
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso3(bool posAnterior = false)
    {
        if (musica.clip != musicaHabitacion[16])
        {
            musica.clip = musicaHabitacion[16];
            musica.Play();
        }
        if (posAnterior)
        {
            player.transform.position = playerPosAnterior;
        }
        else
        {
            player.transform.position = new Vector3(0, 14.63f, 0);
        }    
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
    }
    public void Piso4(bool posAnterior = false)
    {
        if (musica.clip != musicaHabitacion[16])
        {
            musica.clip = musicaHabitacion[16];
            musica.Play();
        }
        if (posAnterior)
        {
            player.transform.position = playerPosAnterior;
        }
        else
        {
            player.transform.position = new Vector3(0, 21.33f, 0);
        }       
        cameraObject.transform.position = player.transform.position;
        if (pet != null)
        {
            pet.transform.position = player.transform.position;
        }
    }

    public void TeleportTo(Vector3 place)
    {
        player.transform.position = place;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
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
        musica.clip = musicaHabitacion[0];
        musica.Play();
        //Detectar nivel de habitacion
        if (manager.huespedDead[0] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[16], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[0], posicionHabitacion.transform.position, Quaternion.identity);
        }     
        //Decirle al activadorHombre que esta muerto y posicionar jugador
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);       
    }
    public void HabitacionMujer(int habitacion)
    {
        musica.clip = musicaHabitacion[1];
        musica.Play();
        //Detectar nivel de habitacion
        if (manager.huespedDead[1] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[17], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[1], posicionHabitacion.transform.position, Quaternion.identity);
        }        
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionPayaso(int habitacion)
    {
        musica.clip = musicaHabitacion[2];
        musica.Play();
        //Detectar nivel de habitacion
        if (manager.huespedDead[2] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[18], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[2], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionMago(int habitacion)
    {
        musica.clip = musicaHabitacion[3];
        musica.Play();
        //Detectar nivel de habitacion
        if (manager.huespedDead[3] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[19], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[3], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionDrogo(int habitacion)
    {
        musica.clip = musicaHabitacion[4];
        musica.Play();
        //Detectar nivel de habitacion
        if (manager.huespedDead[4] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[20], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[4], posicionHabitacion.transform.position, Quaternion.identity);
        }      
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }  
    public void HabitacionMusico(int habitacion)
    {
        musica.clip = musicaHabitacion[5];
        musica.Play();
        //Detectar nivel de habitacion
        if (manager.huespedDead[5] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[21], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[5], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }   
    public void HabitacionCastaway(int habitacion)
    {
        musica.clip = musicaHabitacion[6];
        musica.Play();
        if (manager.huespedDead[6] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[22], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[6], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionSamurai(int habitacion)
    {
        musica.clip = musicaHabitacion[7];
        musica.Play();
        if (manager.huespedDead[7] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[23], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[7], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionPadrecito(int habitacion)
    {
        musica.clip = musicaHabitacion[8];
        musica.Play();
        if (manager.huespedDead[8] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[24], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[8], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionEskimo(int habitacion)
    {
        musica.clip = musicaHabitacion[9];
        musica.Play();
        if (manager.huespedDead[9] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[25], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[9], posicionHabitacion.transform.position, Quaternion.identity);
        }       
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionSkater(int habitacion)
    {
        musica.clip = musicaHabitacion[10];
        musica.Play();
        if (manager.huespedDead[10] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[26], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[10], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionBlind(int habitacion)
    {
        musica.clip = musicaHabitacion[11];
        musica.Play();
        if (manager.huespedDead[11] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[27], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[11], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionAlien(int habitacion)
    {
        musica.clip = musicaHabitacion[12];
        musica.Play();
        if (manager.huespedDead[12] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[28], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[12], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionTesla(int habitacion)
    {
        musica.clip = musicaHabitacion[13];
        musica.Play();
        if (manager.huespedDead[13] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[29], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[13], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionExplorer(int habitacion)
    {
        musica.clip = musicaHabitacion[14];
        musica.Play();
        if (manager.huespedDead[14] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[30], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[14], posicionHabitacion.transform.position, Quaternion.identity);
        }
        ChecarEstadoHabitacionYPosicionarJugador(habitacion);
    }
    public void HabitacionAstronaut(int habitacion)
    {
        musica.clip = musicaHabitacion[15];
        musica.Play();
        if (manager.huespedDead[15] >= 1)
        {
            Debug.Log("Nivel 2");
            habitacionActualGameObject = Instantiate(habitacionPrefab[31], posicionHabitacion.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel 1");
            habitacionActualGameObject = Instantiate(habitacionPrefab[15], posicionHabitacion.transform.position, Quaternion.identity);
        }
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
        for (int i = 0; i < habitacionUI.Length; i++)
        {
            if (manager.numeroHabitacion[i] != null)
            {
                if (!manager.habitacionDead[i])
                {
                    //Activar icono de moneda
                    moneyIcon[i].SetActive(true);
                    Instantiate(moneyParticle, moneyIcon[i].transform.position, Quaternion.identity);
                    habitacionUI[i].transform.GetChild(0).GetComponent<Text>().text = manager.numeroHabitacion[i].huespedName;
                    //Mandar info a otro script para animarlo
                    habitacionUI[i].transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.numeroHabitacion[i].money;
                    habitacionUI[i].transform.GetChild(2).GetComponent<Image>().sprite = manager.numeroHabitacion[i].sprite;
                    manager.money += manager.numeroHabitacion[i].money;
                    manager.nightsInRoom[i] -= 1;
                    if (manager.nightsInRoom[i] <= 0)
                    {
                        manager.nightsInRoom[i] = 0;
                    }
                    habitacionUI[i].transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.nightsInRoom[i];
                }
                else
                {
                    reputationIcon[i].SetActive(true);
                    habitacionUI[i].transform.GetChild(0).GetComponent<Text>().text = manager.numeroHabitacion[i].huespedName;
                    habitacionUI[i].transform.GetChild(1).GetComponent<Text>().text = "R" + manager.numeroHabitacion[i].reputation;
                    habitacionUI[i].transform.GetChild(2).GetComponent<Image>().sprite = manager.numeroHabitacion[i].sprite;
                    manager.reputation += manager.numeroHabitacion[i].reputation;
                    manager.nightsInRoom[i] = 0;
                    habitacionUI[i].transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.nightsInRoom[i];
                }
            }
            stats.SetMoney();
            stats.SetReputation();
        }                            

        manager.Guardar();
    }

    //Mejora del hotel- LLamado desde: CompraMejora/CompraDeHabitacion/CompraPiso
    public void AgregarHabitacion(int costo, int reputacion, int id)
    {
        audioSourceCompra.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.habitaciones += 1;
        manager.AgregarHabitacion(id);
        manager.reputation += reputacion;
        stats.SetMoney();
        stats.SetReputation();
    }
    public void CompraMejora(int costo, int reputacion, int id)
    {
        audioSourceCompra.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.MejoraHotel(id);
        manager.reputation += reputacion;
        stats.SetMoney();
        stats.SetReputation();
    }
    public void CompraPiso(int costo, int reputacion, int id)
    {
        audioSourceCompra.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.AgregarPiso(id);
        manager.reputation += reputacion;
        stats.SetMoney();
        stats.SetReputation();
    }
    public void CompraGeneral(int costo, int reputacion)
    {
        audioSourceCompra.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.reputation += reputacion;
        stats.SetMoney();
        stats.SetReputation();
    }
    //Sonido cuando no puede comprar
    public void NoCashSound()
    {
        noCashSound.Play();
    }

    public void FadeToBlack()
    {
        animfadeOut.Play("FadeIn");
    }
}
