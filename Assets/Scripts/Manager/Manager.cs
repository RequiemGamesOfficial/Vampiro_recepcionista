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
    public bool[] habitacionDead = new bool[12];
    public HuespedData[] huespedID;

    //datos a Guardad Data
    public int blood, money, reputation;
    public int noche, habitaciones;
    //h00
    public int[] h = new int[12];
    public int piso3, piso4;
    public int basura1, basura2, basura3, basura4;
    public int playa1, playa2, playa3, japones1, japones2, japones3;
    public HuespedData[] numeroHabitacion = new HuespedData[12];
    //h00Nights
    public int[] nightsInRoom = new int[12];
    //h00ID
    public int[] habitacionID = new int[12];
    public int[] huespedDead = new int[16];
    public int skin;

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

    //Llamado desde Recepcion
    public void AgregarHuespedEnHabitacionEspecifica(HuespedData huespedData, int habitacion)
    {
        numeroHabitacion[habitacion] = huespedData;
        nightsInRoom[habitacion] = huespedData.nights;
        habitacionID[habitacion] = huespedData.id;
    }  

    //Llamado en Recepcion para vaciar habitaciones
    public void ResetearHabitaciones()
    {
        for (int i = 0; i < numeroHabitacion.Length; i++)
        {
            numeroHabitacion[i] = null;
        }
    }

    //Compras de Hotel
    public void AgregarHabitacion(int habitacion)
    {
        h[habitacion] += 1;               
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
        for (int i = 0; i < numeroHabitacion.Length; i++)
        {
            //si una habitacion tiene un huesped con noches pendientes
            if (nightsInRoom[i] >= 1)
            {
                //se asigna el HuespedData a la habitacion
                numeroHabitacion[i] = huespedID[habitacionID[i]];
            }
        }            
    }
    //Contar muerte de huesped 
    public void HuespedDead(int id)
    {
        huespedDead[id] += 1;
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
            noche = noche,
            habitaciones = habitaciones,
            h4 = h[3],
            h5 = h[4],
            h6 = h[5],
            h7 = h[6],
            h8 = h[7],
            h9 = h[8],
            h10 = h[9],
            h11 = h[10],
            h12 = h[11],
            h1Nights = nightsInRoom[0],
            h2Nights = nightsInRoom[1],
            h3Nights = nightsInRoom[2],
            h4Nights = nightsInRoom[3],
            h5Nights = nightsInRoom[4],
            h6Nights = nightsInRoom[5],
            h7Nights = nightsInRoom[6],
            h8Nights = nightsInRoom[7],
            h9Nights = nightsInRoom[8],
            h10Nights = nightsInRoom[9],
            h11Nights = nightsInRoom[10],
            h12Nights = nightsInRoom[11],
            h1ID = habitacionID[0],
            h2ID = habitacionID[1],
            h3ID = habitacionID[2],
            h4ID = habitacionID[3],
            h5ID = habitacionID[4],
            h6ID = habitacionID[5],
            h7ID = habitacionID[6],
            h8ID = habitacionID[7],
            h9ID = habitacionID[8],
            h10ID = habitacionID[9],
            h11ID = habitacionID[10],
            h12ID = habitacionID[11],
            piso3 = piso3, 
            piso4 = piso4,
            basura1= basura1,
            basura2=basura2,
            basura3=basura3,
            basura4=basura4,
            //huespedes
            huespedDead1 = huespedDead[0],
            huespedDead2 = huespedDead[1],
            huespedDead3 = huespedDead[2],
            huespedDead4 = huespedDead[3],
            huespedDead5 = huespedDead[4],
            huespedDead6 = huespedDead[5],
            huespedDead7 = huespedDead[6],
            huespedDead8 = huespedDead[7],
            huespedDead9 = huespedDead[8],
            huespedDead10 = huespedDead[9],
            huespedDead11 = huespedDead[10],
            huespedDead12 = huespedDead[11],
            huespedDead13 = huespedDead[12],
            huespedDead14 = huespedDead[13],
            huespedDead15 = huespedDead[14],
            huespedDead16 = huespedDead[15],
            skin = skin
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
            noche = 0,
            habitaciones = 3,
            h4 = 0,
            h5 = 0,
            h6 = 0,
            h7 = 0,
            h8 = 0,
            h9 = 0,
            h10 = 0,
            h11 = 0,
            h12 = 0,
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
            basura4 = 0,
            //huespedes
            huespedDead1 = 0,
            huespedDead2 = 0,
            huespedDead3 = 0,
            huespedDead4 = 0,
            huespedDead5 = 0,
            huespedDead6 = 0,
            huespedDead7 = 0,
            huespedDead8 = 0,
            huespedDead9 = 0,
            huespedDead10 = 0,
            huespedDead11 = 0,
            huespedDead12 = 0,
            huespedDead13 = 0,
            huespedDead14 = 0,
            huespedDead15 = 0,
            huespedDead16 = 0,
            skin = 0
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
            noche = data.noche;
            habitaciones = data.habitaciones;
            h[3] = data.h4;
            h[4] = data.h5;
            h[5] = data.h6;
            h[6] = data.h7;
            h[7] = data.h8;
            h[8] = data.h9;
            h[9] = data.h10;
            h[10] = data.h11;
            h[11] = data.h12;
            nightsInRoom[0] = data.h1Nights;
            nightsInRoom[1] = data.h2Nights;
            nightsInRoom[2] = data.h3Nights;
            nightsInRoom[3] = data.h4Nights;
            nightsInRoom[4] = data.h5Nights;
            nightsInRoom[5] = data.h6Nights;
            nightsInRoom[6] = data.h7Nights;
            nightsInRoom[7] = data.h8Nights;
            nightsInRoom[8] = data.h9Nights;
            nightsInRoom[9] = data.h10Nights;
            nightsInRoom[10] = data.h11Nights;
            nightsInRoom[11] = data.h12Nights;
            habitacionID[0] = data.h1ID;
            habitacionID[1] = data.h2ID;
            habitacionID[2] = data.h3ID;
            habitacionID[3] = data.h4ID;
            habitacionID[4] = data.h5ID;
            habitacionID[5] = data.h6ID;
            habitacionID[6] = data.h7ID;
            habitacionID[7] = data.h8ID;
            habitacionID[8] = data.h9ID;
            habitacionID[9] = data.h10ID;
            habitacionID[10] = data.h11ID;
            habitacionID[11] = data.h12ID;
            piso3 = data.piso3;
            piso4 = data.piso4;
            basura1 = data.basura1;
            basura2 = data.basura2;
            basura3 = data.basura3;
            basura4 = data.basura4;
            //huespedes
            huespedDead[0] = data.huespedDead1;
            huespedDead[1] = data.huespedDead2;
            huespedDead[2] = data.huespedDead3;
            huespedDead[3] = data.huespedDead4;
            huespedDead[4] = data.huespedDead5;
            huespedDead[5] = data.huespedDead6;
            huespedDead[6] = data.huespedDead7;
            huespedDead[7] = data.huespedDead8;
            huespedDead[8] = data.huespedDead9;
            huespedDead[9] = data.huespedDead10;
            huespedDead[10] = data.huespedDead11;
            huespedDead[11] = data.huespedDead12;
            huespedDead[12] = data.huespedDead13;
            huespedDead[13] = data.huespedDead14;
            huespedDead[14] = data.huespedDead15;
            huespedDead[15] = data.huespedDead16;
            skin = data.skin;           

            file.Close();
        }
        AsignacioIDs();
    }
}
