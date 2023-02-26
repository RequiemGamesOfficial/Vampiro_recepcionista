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
    public int h4, h5, h6, h7, h8, h9,h10,h11,h12;
    public int piso3, piso4;
    public int basura1, basura2, basura3, basura4;

    public HuespedData habitacion01, habitacion02, habitacion03, habitacion04, habitacion05, habitacion06, habitacion07, habitacion08, habitacion09;
    public HuespedData habitacion10, habitacion11, habitacion12;

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
        if(habitacion == 1 && habitacion01 == null)
        {
            habitacion01 = huespedData;
            return;
        }
        if (habitacion == 2 && habitacion02 == null)
        {
            habitacion02 = huespedData;
            return;
        }
        if (habitacion == 3 && habitacion03 == null)
        {
            habitacion03 = huespedData;
            return;
        }
        if (habitacion == 4 && habitacion04 == null)
        {
            habitacion04 = huespedData;
            return;
        }
        if (habitacion == 5 && habitacion05 == null)
        {
            habitacion05 = huespedData;
            return;
        }
        if (habitacion == 6 && habitacion06 == null)
        {
            habitacion06 = huespedData;
            return;
        }
        if (habitacion == 7 && habitacion07 == null)
        {
            habitacion07 = huespedData;
            return;
        }
        if (habitacion == 8 && habitacion08 == null)
        {
            habitacion08 = huespedData;
            return;
        }
        if (habitacion == 9 && habitacion09 == null)
        {
            habitacion09 = huespedData;
            return;
        }
        if (habitacion == 10 && habitacion10 == null)
        {
            habitacion10 = huespedData;
            return;
        }
        if (habitacion == 11 && habitacion11 == null)
        {
            habitacion11 = huespedData;
            return;
        }
        if (habitacion == 12 && habitacion12 == null)
        {
            habitacion12 = huespedData;
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
    public void QuitarBasura(int basura)
    {
        if(basura == 1)
        {
            basura1 += 1;
        }
        if (basura == 2)
        {
            basura2 += 1;
        }
        if (basura == 3)
        {
            basura3 += 1;
        }
        if (basura == 4)
        {
            basura4 += 1;
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
            h4 = h4, 
            h5 = h5, 
            h6 = h6, 
            h7 = h7, 
            h8 = h8, 
            h9 = h9,
            h10=h10,
            h11=h11,
            h12=h12,
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
            h4 = 0,
            h5 = 0,
            h6 = 0,
            h7 = 0,
            h8 = 0,
            h9 = 0,
            h10 =0,
            h11=0,
            h12=0,
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
            h4 = data.h4;
            h5 = data.h5;
            h6 = data.h6;
            h7 = data.h7;
            h8 = data.h8; 
            h9 = data.h9;
            h10 = data.h10;
            h11 = data.h11;
            h12 = data.h12;
            piso3 = data.piso3;
            piso4 = data.piso4;
            basura1 = data.basura1;
            basura2 = data.basura2;
            basura3 = data.basura3;
            basura4 = data.basura4;

            file.Close();
        }
    }
}
