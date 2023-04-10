using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    //datos a Guardad
    public int blood, money, reputation;
    public int noche, habitaciones;
    public int habitacionesDisponibles;
    public int h4, h5, h6, h7, h8, h9,h10,h11,h12;
    public int piso3, piso4;
    public int basura1, basura2, basura3, basura4;
    public int playa1, playa2, playa3, japones1, japones2, japones3;

    public HuespedData habitacion01, habitacion02, habitacion03, habitacion04, habitacion05, habitacion06, habitacion07, habitacion08, habitacion09;
    public HuespedData habitacion10, habitacion11, habitacion12;
    public HuespedData hombre, mujer, payaso, mago, drogo, musico, naufrago, samurai, padrecito, esquimal, patineto, ciego, marciano, tesla, explorador, astronauta;

    public int h1Nights, h2Nights, h3Nights, h4Nights, h5Nights, h6Nights, h7Nights, h8Nights, h9Nights, h10Nights, h11Nights, h12Nights;
    public int h1ID, h2ID, h3ID, h4ID, h5ID, h6ID, h7ID, h8ID, h9ID, h10ID, h11ID, h12ID;

    public bool habitacion01Dead, habitacion02Dead, habitacion03Dead, habitacion04Dead, habitacion05Dead, habitacion06Dead, habitacion07Dead, habitacion08Dead, habitacion09Dead, habitacion10Dead, habitacion11Dead, habitacion12Dead;


    private String filePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "save.dat";
    }

    public void AgregarHuespedEnHabitacionEspecifica(HuespedData huespedData, int habitacion)
    {
        if(habitacion == 1)
        {
            habitacion01 = huespedData;
            h1Nights = huespedData.nights;
            h1ID = huespedData.id;
            return;
        }
        if (habitacion == 2)
        {
            habitacion02 = huespedData;
            h2Nights = huespedData.nights;
            h2ID = huespedData.id;
            return;
        }
        if (habitacion == 3)
        {
            habitacion03 = huespedData;
            h3Nights = huespedData.nights;
            h3ID = huespedData.id;
            return;
        }
        if (habitacion == 4)
        {
            habitacion04 = huespedData;
            h4Nights = huespedData.nights;
            h4ID = huespedData.id;
            return;
        }
        if (habitacion == 5)
        {
            habitacion05 = huespedData;
            h5Nights = huespedData.nights;
            h5ID = huespedData.id;
            return;
        }
        if (habitacion == 6)
        {
            habitacion06 = huespedData;
            h6Nights = huespedData.nights;
            h6ID = huespedData.id;
            return;
        }
        if (habitacion == 7)
        {
            habitacion07 = huespedData;
            h7Nights = huespedData.nights;
            h7ID = huespedData.id;
            return;
        }
        if (habitacion == 8)
        {
            habitacion08 = huespedData;
            h8Nights = huespedData.nights;
            h8ID = huespedData.id;
            return;
        }
        if (habitacion == 9)
        {
            habitacion09 = huespedData;
            h9Nights = huespedData.nights;
            h9ID = huespedData.id;
            return;
        }
        if (habitacion == 10)
        {
            habitacion10 = huespedData;
            h10Nights = huespedData.nights;
            h10ID = huespedData.id;
            return;
        }
        if (habitacion == 11)
        {
            habitacion11 = huespedData;
            h11Nights = huespedData.nights;
            h11ID = huespedData.id;
            return;
        }
        if (habitacion == 12)
        {
            habitacion12 = huespedData;
            h12Nights = huespedData.nights;
            h12ID = huespedData.id;
            return;
        }
    }  

    //Llamado en Recepcion para vaciar habitaciones
    public void ResetearHabitaciones()
    {
        habitacion01 = null;
        habitacion02 = null;
        habitacion03 = null;
        habitacion04 = null;
        habitacion05 = null;
        habitacion06 = null;
        habitacion07 = null;
        habitacion08 = null;
        habitacion09 = null;
        habitacion10 = null;
        habitacion11 = null;
        habitacion12 = null;
    }

    //Compras de Hotel
    public void AgregarHabitacion(int habitacion)
    {
        if(habitacion == 4)
        {
            h4 += 1;
            return;
        }
        if (habitacion == 5)
        {
            h5 += 1;
            return;
        }
        if (habitacion == 6)
        {
            h6 += 1;
            return;
        }
        if (habitacion == 7)
        {
            h7 += 1;
            return;
        }
        if (habitacion == 8)
        {
            h8 += 1;
            return;
        }
        if (habitacion == 9)
        {
            h9 += 1;
            return;
        }
        if (habitacion == 10)
        {
            h10 += 1;
            return;
        }
        if (habitacion == 11)
        {
            h11 += 1;
            return;
        }
        if (habitacion == 12)
        {
            h12 += 1;
        }
    }
    public void AgregarPiso(int piso)
    {
        if(piso == 3)
        {
            piso3 += 1;
        }
        if (piso == 4)
        {
            piso4 += 1;
        }
    }
    public void MejoraHotel(int mejora)
    {
        if(mejora == 0)
        {
            return;
        }
        
        if(mejora == 1)
        {
            basura1 += 1;
            return;
        }
        if (mejora == 2)
        {
            basura2 += 1;
            return;
        }
        if (mejora == 3)
        {
            basura3 += 1;
            return;
        }
        if (mejora == 4)
        {
            basura4 += 1;
            return;
        }
        //Adornos
        if (mejora == 5)
        {
            playa1 += 1;
            return;
        }
        if (mejora == 6)
        {
            playa2 += 1;
            return;
        }
        if (mejora == 7)
        {
            playa3 += 1;
            return;
        }
        if (mejora == 8)
        {
            japones1 += 1;
            return;
        }
        if (mejora == 9)
        {
            japones2 += 1;
            return;
        }
        if (mejora == 10)
        {
            japones3 += 1;
            return;
        }
    }
    //AsignarIDhabitaciones, poner huespedes en las habitaciones/ llamado desde Cargar();
    public void AsignacioIDs()
    {
        Debug.Log("AsignarHabitacion");
        if(h1Nights >= 1)
        {
            Habitacion1ID(h1ID);
        }
        if (h2Nights >= 1)
        {
            Habitacion2ID(h2ID);
        }
        if (h3Nights >= 1)
        {
            Habitacion3ID(h3ID);
        }
        if (h4Nights >= 1)
        {
            Habitacion4ID(h4ID);
        }
        if (h5Nights >= 1)
        {
            Habitacion5ID(h5ID);
        }
        if (h6Nights >= 1)
        {
            Habitacion6ID(h6ID);
        }
        if (h7Nights >= 1)
        {
            Habitacion7ID(h7ID);
        }
        if (h8Nights >= 1)
        {
            Habitacion8ID(h8ID);
        }
        if (h9Nights >= 1)
        {
            Habitacion9ID(h9ID);
        }
        if (h10Nights >= 1)
        {
            Habitacion10ID(h10ID);
        }
        if (h11Nights >= 1)
        {
            Habitacion11ID(h11ID);
        }
        if (h12Nights >= 1)
        {
            Habitacion12ID(h12ID);
        }        
    }
    public void Habitacion1ID(int id)
    {
        Debug.Log("Habitacion1ID");
        if (id == 1)
        {
            habitacion01 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion01 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion01 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion01 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion01 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion01 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion01 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion01 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion01 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion01 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion01 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion01 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion01 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion01 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion01 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion01 = astronauta;
            return;
        }
    }
    public void Habitacion2ID(int id)
    {
        if (id == 1)
        {
            habitacion02 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion02 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion02 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion02 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion02 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion02 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion02 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion02 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion02 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion02 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion02 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion02 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion02 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion02 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion02 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion02 = astronauta;
            return;
        }
    }
    public void Habitacion3ID(int id)
    {
        if (id == 1)
        {
            habitacion03 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion03 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion03 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion03 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion03 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion03 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion03 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion03 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion03 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion03 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion03 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion03 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion03 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion03 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion03 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion03 = astronauta;
            return;
        }
    }
    public void Habitacion4ID(int id)
    {
        if (id == 1)
        {
            habitacion04 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion04 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion04 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion04 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion04 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion04 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion04 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion04 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion04 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion04 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion04 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion04 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion04 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion04 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion04 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion04 = astronauta;
            return;
        }
    }
    public void Habitacion5ID(int id)
    {
        if (id == 1)
        {
            habitacion05 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion05 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion05 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion05 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion05 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion05 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion05 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion05 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion05 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion05 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion05 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion05 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion05 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion05 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion05 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion05 = astronauta;
            return;
        }
    }
    public void Habitacion6ID(int id)
    {
        if (id == 1)
        {
            habitacion06 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion06 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion06 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion06 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion06 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion06 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion06 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion06 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion06 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion06 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion06 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion06 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion06 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion06 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion06 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion06 = astronauta;
            return;
        }
    }
    public void Habitacion7ID(int id)
    {
        if (id == 1)
        {
            habitacion07 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion07 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion07 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion07 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion07 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion07 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion07 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion07 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion07 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion07 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion07 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion07 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion07 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion07 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion07 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion07 = astronauta;
            return;
        }
    }
    public void Habitacion8ID(int id)
    {
        if (id == 1)
        {
            habitacion08 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion08 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion08 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion08 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion08 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion08 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion08 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion08 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion08 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion08 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion08 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion08 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion08 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion08 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion08 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion08 = astronauta;
            return;
        }
    }
    public void Habitacion9ID(int id)
    {
        if (id == 1)
        {
            habitacion09 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion09 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion09 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion09 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion09 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion09 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion09 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion09 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion09 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion09 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion09 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion09 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion09 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion09 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion09 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion09 = astronauta;
            return;
        }
    }
    public void Habitacion10ID(int id)
    {
        if (id == 1)
        {
            habitacion10 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion10 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion10 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion10 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion10 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion10 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion10 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion10 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion10 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion10 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion10 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion10 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion10 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion10 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion10 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion10 = astronauta;
            return;
        }
    }
    public void Habitacion11ID(int id)
    {
        if (id == 1)
        {
            habitacion11 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion11 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion11 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion11 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion11 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion11 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion11 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion11 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion11 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion11 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion11 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion11 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion11 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion11 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion11 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion11 = astronauta;
            return;
        }
    }
    public void Habitacion12ID(int id)
    {
        if (id == 1)
        {
            habitacion12 = hombre;
            return;
        }
        if (id == 2)
        {
            habitacion12 = mujer;
            return;
        }
        if (id == 3)
        {
            habitacion12 = payaso;
            return;
        }
        if (id == 4)
        {
            habitacion12 = mago;
            return;
        }
        if (id == 5)
        {
            habitacion12 = drogo;
            return;
        }
        if (id == 6)
        {
            habitacion12 = musico;
            return;
        }
        if (id == 7)
        {
            habitacion12 = naufrago;
            return;
        }
        if (id == 8)
        {
            habitacion12 = samurai;
            return;
        }
        if (id == 9)
        {
            habitacion12 = padrecito;
            return;
        }
        if (id == 10)
        {
            habitacion12 = esquimal;
            return;
        }
        if (id == 11)
        {
            habitacion12 = patineto;
            return;
        }
        if (id == 12)
        {
            habitacion12 = ciego;
            return;
        }
        if (id == 13)
        {
            habitacion12 = marciano;
            return;
        }
        if (id == 14)
        {
            habitacion12 = tesla;
            return;
        }
        if (id == 15)
        {
            habitacion12 = explorador;
            return;
        }
        if (id == 16)
        {
            habitacion12 = astronauta;
            return;
        }
    }
    //DataManager
    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        DataSave data = new DataSave
        {
            //Datos a Guardar 
            blood = blood,
            money = money,
            reputation = reputation,
            dia = noche,
            habitaciones = habitaciones,
            habitacionesDisponibles = habitacionesDisponibles,
            h4 = h4,
            h5 = h5,
            h6 = h6,
            h7 = h7,
            h8 = h8,
            h9 = h9,
            h10 = h10,
            h11 = h11,
            h12 = h12,
            h1Nights = h1Nights,
            h2Nights = h2Nights,
            h3Nights = h3Nights,
            h4Nights = h4Nights,
            h5Nights = h5Nights,
            h6Nights = h6Nights,
            h7Nights = h7Nights,
            h8Nights = h8Nights,
            h9Nights = h9Nights,
            h10Nights = h10Nights,
            h11Nights = h11Nights,
            h12Nights = h12Nights,
            h1ID =h1ID,
            h2ID = h2ID,
            h3ID = h3ID,
            h4ID = h4ID,
            h5ID = h5ID,
            h6ID = h6ID,
            h7ID = h7ID,
            h8ID = h8ID,
            h9ID = h9ID,
            h10ID = h10ID,
            h11ID = h11ID,
            h12ID = h12ID,
            piso3 = piso3, 
            piso4 = piso4,
            basura1= basura1,
            basura2=basura2,
            basura3=basura3,
            basura4=basura4
        };

        bf.Serialize(file, data);
        file.Close();
        //Cargar();
    }
    public void Restart()
    {
        Debug.Log("Restart");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        DataSave data = new DataSave
        {
            //Datos a Guardar 
            blood = 50,
            money = 0,
            reputation = 50,
            dia = 0,
            habitaciones = 3,
            habitacionesDisponibles = 3,
            h4 = 0,
            h5 = 0,
            h6 = 0,
            h7 = 0,
            h8 = 0,
            h9 = 0,
            h10 =0,
            h11=0,
            h12=0,
            h1Nights = 0,
            h2Nights = 0,
            h3Nights = 0,
            h4Nights = 0,
            h5Nights = 0,
            h6Nights = 0,
            h7Nights = 0,
            h8Nights = 0,
            h9Nights = 0,
            h10Nights = 0,
            h11Nights = 0,
            h12Nights = 0,
            h1ID = 0,
            h2ID = 0,
            h3ID = 0,
            h4ID = 0,
            h5ID = 0,
            h6ID = 0,
            h7ID = 0,
            h8ID = 0,
            h9ID = 0,
            h10ID = 0,
            h11ID = 0,
            h12ID = 0,
            piso3 = 0,
            piso4 = 0,
            basura1 = 0,
            basura2 = 0,
            basura3 = 0,
            basura4 = 0
        };

        ResetearHabitaciones();

        bf.Serialize(file, data);
        file.Close();
        Cargar();

        //SceneManager.LoadSceneAsync("Nivel1.1", LoadSceneMode.Single);
    }
    public void Cargar()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            DataSave data = (DataSave)bf.Deserialize(file);

            //Datos a cargar
            blood = data.blood;
            money = data.money;
            reputation = data.reputation;
            noche = data.dia;
            habitaciones = data.habitaciones;
            habitacionesDisponibles = data.habitacionesDisponibles;
            h4 = data.h4;
            h5 = data.h5;
            h6 = data.h6;
            h7 = data.h7;
            h8 = data.h8; 
            h9 = data.h9;
            h10 = data.h10;
            h11 = data.h11;
            h12 = data.h12;
            h1Nights = data.h1Nights;
            h2Nights = data.h2Nights;
            h3Nights = data.h3Nights;
            h4Nights = data.h4Nights;
            h5Nights = data.h5Nights;
            h6Nights = data.h6Nights;
            h7Nights = data.h7Nights;
            h8Nights = data.h8Nights;
            h9Nights = data.h9Nights;
            h10Nights = data.h10Nights;
            h11Nights = data.h11Nights;
            h12Nights = data.h12Nights;
            h1ID = data.h1ID;
            h2ID = data.h2ID;
            h3ID = data.h3ID;
            h4ID = data.h4ID;
            h5ID = data.h5ID;
            h6ID = data.h6ID;
            h7ID = data.h7ID;
            h8ID = data.h8ID;
            h9ID = data.h9ID;
            h10ID = data.h10ID;
            h11ID = data.h11ID;
            h12ID = data.h12ID;
            piso3 = data.piso3;
            piso4 = data.piso4;
            basura1 = data.basura1;
            basura2 = data.basura2;
            basura3 = data.basura3;
            basura4 = data.basura4;

            file.Close();
        }
        AsignacioIDs();
    }
}
