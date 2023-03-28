using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotel : MonoBehaviour
{
    public Manager manager;

    public GameObject player,cameraObject;

    public GameObject puerta101, puerta102, puerta103, puerta201, puerta202, puerta203;
    public GameObject puerta301, puerta302, puerta303, puerta401, puerta402, puerta403;
    public GameObject habitacion1UI, habitacion2UI, habitacion3UI, habitacion4UI, habitacion5UI, habitacion6UI, habitacion7UI, habitacion8UI, habitacion9UI, habitacion10UI, habitacion11UI, habitacion12UI;

    public GameObject tablasH4, tablasH5, tablasH6;
    public GameObject tablasH7, tablasH8, tablasH9;
    public GameObject tablasH10, tablasH11, tablasH12;
    public GameObject piso3Construccion, piso3Azotea, piso3, piso3Compra;
    public GameObject piso4Construccion, piso4Azotea, piso4, piso4Compra;
    public GameObject numeroHPiso3, numeroHPiso4;
    public GameObject basura1, basura2, basura3, basura4;

    //Habitaciones
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
    public GameObject hHombrePrefab, hMujerPrefab,hPayasoPrefab, hMagoPrefab, hDrogoPrefab, hMusicoPrefab, hNaufragoPrefab, hSamuraiPrefab;
    public GameObject hPadrecitoPrefab, hEsquimalPrefab, hPatinetoPrefab, hCiegoPrefab, hMarcianoPrefab, hTeslaPrefab, hExploradoraPrefab, hAstronautaPrefab;

    GameObject habitacionActualGameObject;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        textNoche.text = (":" + manager.noche);

        //ActivarPuertas/pisos/adornos y DesactivarBasura
        if (manager.h4 >= 1)
        {
            tablasH4.SetActive(false);
            puerta201.SetActive(true);
        }
        if(manager.h5 >= 1)
        {
            tablasH5.SetActive(false);
            puerta202.SetActive(true);
        }
        if(manager.h6 >= 1)
        {
            tablasH6.SetActive(false);
            puerta203.SetActive(true);
        }
        //
        if (manager.h7 >= 1)
        {
            tablasH7.SetActive(false);
            puerta301.SetActive(true);
        }
        if (manager.h8 >= 1)
        {
            tablasH8.SetActive(false);
            puerta302.SetActive(true);
        }
        if (manager.h9 >= 1)
        {
            tablasH9.SetActive(false);
            puerta303.SetActive(true);
        }
        //
        if (manager.h10 >= 1)
        {
            tablasH10.SetActive(false);
            puerta401.SetActive(true);
        }
        if (manager.h11 >= 1)
        {
            tablasH11.SetActive(false);
            puerta402.SetActive(true);
        }
        if (manager.h12 >= 1)
        {
            tablasH12.SetActive(false);
            puerta403.SetActive(true);
        }

        if (manager.basura1 >= 1)
        {
            basura1.SetActive(false);
        }
        if (manager.basura2 >= 1)
        {
            basura2.SetActive(false);
        }
        if (manager.basura3 >= 1)
        {
            basura3.SetActive(false);
        }
        if (manager.basura4 >= 1)
        {
            basura4.SetActive(false);
        }

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

        //Poner Huespedes en habitaciones
        if (manager.habitacion01 != null)
        {
            puerta101.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion01.huespedName;
        }
        if (manager.habitacion02 != null)
        {
            puerta102.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion02.huespedName;
        }
        if (manager.habitacion03 != null)
        {
            puerta103.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion03.huespedName;
        }
        if (manager.habitacion04 != null)
        {
            puerta201.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion04.huespedName;
        }
        //
        if (manager.habitacion05 != null)
        {
            puerta202.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion05.huespedName;
        }
        if (manager.habitacion06 != null)
        {
            puerta203.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion06.huespedName;
        }
        if (manager.habitacion07 != null)
        {
            puerta301.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion07.huespedName;
        }
        if (manager.habitacion08 != null)
        {
            puerta302.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion08.huespedName;
        }
        if (manager.habitacion09 != null)
        {
            puerta303.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion09.huespedName;
        }
        if (manager.habitacion10 != null)
        {
            puerta401.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion10.huespedName;
        }
        if (manager.habitacion11 != null)
        {
            puerta402.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion11.huespedName;
        }
        if (manager.habitacion12 != null)
        {
            puerta403.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion12.huespedName;
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
    public void Piso1()
    {
        player.transform.position = new Vector3(0, 0f, 0);
        Debug.Log("BorrarHabitacionCreada");
        if(habitacionActualGameObject != null)
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
    //Actualizar muertes
    public void AsesinatoHabitacion()
    {
        if (habitacionActual == "habitacion1")
        {
            manager.habitacion01Dead = true;
            return;
        }
        if (habitacionActual == "habitacion2")
        {
            manager.habitacion02Dead = true;
            return;
        }
        if (habitacionActual == "habitacion3")
        {
            manager.habitacion03Dead = true;
            return;
        }
        if (habitacionActual == "habitacion4")
        {
            manager.habitacion04Dead = true;
            return;
        }
        if (habitacionActual == "habitacion5")
        {
            manager.habitacion05Dead = true;
            return;
        }
        if (habitacionActual == "habitacion6")
        {
            manager.habitacion06Dead = true;
            return;
        }
        if (habitacionActual == "habitacion7")
        {
            manager.habitacion07Dead = true;
            return;
        }
        if (habitacionActual == "habitacion8")
        {
            manager.habitacion08Dead = true;
            return;
        }
        if (habitacionActual == "habitacion9")
        {
            manager.habitacion09Dead = true;
            return;
        }
        if (habitacionActual == "habitacion10")
        {
            manager.habitacion10Dead = true;
            return;
        }
        if (habitacionActual == "habitacion11")
        {
            manager.habitacion11Dead = true;
            return;
        }
        if (habitacionActual == "habitacion12")
        {
            manager.habitacion12Dead = true;
            return;
        }
    }

    //Checar Habitaciones Para los resultados-Llamado desde TimerHotel al terminar el tiempo
    public void ChecarHaibitaciones()
    {
        manager.habitacionesDisponibles = manager.habitaciones;
        if (manager.habitacion01 != null)
        {
            if (!manager.habitacion01Dead)
            {
                habitacion1UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion01.huespedName;
                habitacion1UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion01.money;
                habitacion1UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion01.sprite;
                manager.money += manager.habitacion01.money;
                manager.h1Nights -= 1;
                if(manager.h1Nights <= 0)
                {
                    manager.h1Nights = 0;
                    //manager.h1ID = 0;
                }
                habitacion1UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h1Nights;
                if(manager.h1Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion1UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion01.huespedName;
                habitacion1UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion01.reputation;
                habitacion1UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion01.sprite;
                manager.reputation += manager.habitacion01.reputation;
                manager.h1Nights = 0;
                habitacion1UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h1Nights;
            }            
        }
        if (manager.habitacion02 != null)
        {
            if (!manager.habitacion02Dead)
            {
                habitacion2UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion02.huespedName;
                habitacion2UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion02.money;
                habitacion2UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion02.sprite;
                manager.money += manager.habitacion02.money;
                manager.h2Nights -= 1;
                if (manager.h2Nights <= 0)
                {
                    manager.h2Nights = 0;
                }
                habitacion2UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h2Nights;
                if (manager.h2Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion2UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion02.huespedName;
                habitacion2UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion02.reputation;
                habitacion2UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion02.sprite;
                manager.reputation += manager.habitacion02.reputation;
                manager.h2Nights = 0;
                habitacion2UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h2Nights;
            }
        }
        if (manager.habitacion03 != null)
        {
            if (!manager.habitacion03Dead)
            {
                habitacion3UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion03.huespedName;
                habitacion3UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion03.money;
                habitacion3UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion03.sprite;
                manager.money += manager.habitacion03.money;
                manager.h3Nights -= 1;
                if (manager.h3Nights <= 0)
                {
                    manager.h3Nights = 0;
                }
                habitacion3UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h3Nights;
                if (manager.h3Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion3UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion03.huespedName;
                habitacion3UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion03.reputation;
                habitacion3UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion03.sprite;
                manager.reputation += manager.habitacion03.reputation;
                manager.h3Nights = 0;
                habitacion3UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h3Nights;
            }
        }
        if (manager.habitacion04 != null)
        {
            if (!manager.habitacion04Dead)
            {
                habitacion4UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion04.huespedName;
                habitacion4UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion04.money;
                habitacion4UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion04.sprite;
                manager.money += manager.habitacion04.money;
                manager.h4Nights -= 1;
                if (manager.h4Nights <= 0)
                {
                    manager.h4Nights = 0;
                }
                habitacion4UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h4Nights;
                if (manager.h4Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion4UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion04.huespedName;
                habitacion4UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion04.reputation;
                habitacion4UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion04.sprite;
                manager.reputation += manager.habitacion04.reputation;
                manager.h4Nights = 0;
                habitacion4UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h4Nights;
            }
        }
        if (manager.habitacion05 != null)
        {
            if (!manager.habitacion05Dead)
            {
                habitacion5UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion05.huespedName;
                habitacion5UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion05.money;
                habitacion5UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion05.sprite;
                manager.money += manager.habitacion05.money;
                manager.h5Nights -= 1;
                if (manager.h5Nights <= 0)
                {
                    manager.h5Nights = 0;
                }
                habitacion5UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h5Nights;
                if (manager.h5Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion5UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion05.huespedName;
                habitacion5UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion05.reputation;
                habitacion5UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion05.sprite;
                manager.reputation += manager.habitacion05.reputation;
                manager.h5Nights = 0;
                habitacion5UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h5Nights;
            }
        }
        if (manager.habitacion06 != null)
        {
            if (!manager.habitacion06Dead)
            {
                habitacion6UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion06.huespedName;
                habitacion6UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion06.money;
                habitacion6UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion06.sprite;
                manager.money += manager.habitacion06.money;
                manager.h6Nights -= 1;
                if (manager.h6Nights <= 0)
                {
                    manager.h6Nights = 0;
                }
                habitacion6UI.transform.GetChild(3).GetComponent<Text>().text = "N-" + manager.h6Nights;
                if (manager.h6Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion6UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion06.huespedName;
                habitacion6UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion06.reputation;
                habitacion6UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion06.sprite;
                manager.reputation += manager.habitacion06.reputation;
                manager.h6Nights = 0;
                habitacion6UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h6Nights;
            }
        }
        if (manager.habitacion07 != null)
        {
            if (!manager.habitacion07Dead)
            {
                habitacion7UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion07.huespedName;
                habitacion7UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion07.money;
                habitacion7UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion07.sprite;
                manager.money += manager.habitacion07.money;
                manager.h7Nights -= 1;
                if (manager.h7Nights <= 0)
                {
                    manager.h7Nights = 0;
                }
                habitacion7UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h7Nights;
                if (manager.h7Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion7UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion07.huespedName;
                habitacion7UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion07.reputation;
                habitacion7UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion07.sprite;
                manager.reputation += manager.habitacion07.reputation;
                manager.h7Nights = 0;
                habitacion7UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h7Nights;
            }
        }
        if (manager.habitacion08 != null)
        {
            if (!manager.habitacion08Dead)
            {
                habitacion8UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion08.huespedName;
                habitacion8UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion08.money;
                habitacion8UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion08.sprite;
                manager.money += manager.habitacion08.money;
                manager.h8Nights -= 1;
                if (manager.h8Nights <= 0)
                {
                    manager.h8Nights = 0;
                }
                habitacion8UI.transform.GetChild(3).GetComponent<Text>().text = "N-" + manager.h8Nights;
                if (manager.h8Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion8UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion08.huespedName;
                habitacion8UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion08.reputation;
                habitacion8UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion08.sprite;
                manager.reputation += manager.habitacion08.reputation;
                manager.h8Nights = 0;
                habitacion8UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h8Nights;
            }
        }
        if (manager.habitacion09 != null)
        {
            if (!manager.habitacion09Dead)
            {
                habitacion9UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion09.huespedName;
                habitacion9UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion09.money;
                habitacion9UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion09.sprite;
                manager.money += manager.habitacion09.money;
                manager.h9Nights -= 1;
                if (manager.h9Nights <= 0)
                {
                    manager.h9Nights = 0;
                }
                habitacion9UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h9Nights;
                if (manager.h9Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion9UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion09.huespedName;
                habitacion9UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion09.reputation;
                habitacion9UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion09.sprite;
                manager.reputation += manager.habitacion09.reputation;
                manager.h9Nights = 0;
                habitacion9UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h9Nights;
            }
        }
        if (manager.habitacion10 != null)
        {
            if (!manager.habitacion10Dead)
            {
                habitacion10UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion10.huespedName;
                habitacion10UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion10.money;
                habitacion10UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion10.sprite;
                manager.money += manager.habitacion10.money;
                manager.h10Nights -= 1;
                if (manager.h10Nights <= 0)
                {
                    manager.h10Nights = 0;
                }
                habitacion10UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h10Nights;
                if (manager.h10Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion10UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion10.huespedName;
                habitacion10UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion10.reputation;
                habitacion10UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion10.sprite;
                manager.reputation += manager.habitacion10.reputation;
                manager.h10Nights = 0;
                habitacion10UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h10Nights;
            }
        }
        if (manager.habitacion11 != null)
        {
            if (!manager.habitacion11Dead)
            {
                habitacion11UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion11.huespedName;
                habitacion11UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion11.money;
                habitacion11UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion11.sprite;
                manager.money += manager.habitacion11.money;
                manager.h11Nights -= 1;
                if (manager.h11Nights <= 0)
                {
                    manager.h11Nights = 0;
                }
                habitacion11UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h11Nights;
                if (manager.h11Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion11UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion11.huespedName;
                habitacion11UI.transform.GetChild(1).GetComponent<Text>().text = "Reputation " + manager.habitacion11.reputation;
                habitacion11UI.transform.GetChild(2).GetComponent<Image>().sprite = manager.habitacion11.sprite;
                manager.reputation += manager.habitacion11.reputation;
                manager.h11Nights = 0;
                habitacion11UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h11Nights;
            }
        }
        if (manager.habitacion12 != null)
        {
            if (!manager.habitacion12Dead)
            {
                habitacion12UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion12.huespedName;
                habitacion12UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion12.money;
                manager.money += manager.habitacion12.money;
                manager.h12Nights -= 1;
                if (manager.h12Nights <= 0)
                {
                    manager.h12Nights = 0;
                }
                habitacion12UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h12Nights;
                if (manager.h12Nights >= 1)
                {
                    manager.habitacionesDisponibles -= 1;
                }
            }
            else
            {
                habitacion12UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion12.huespedName;
                habitacion12UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion12.reputation;
                manager.reputation += manager.habitacion12.reputation;
                manager.h12Nights = 0;
                habitacion12UI.transform.GetChild(3).GetComponent<Text>().text = "N:" + manager.h12Nights;
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
