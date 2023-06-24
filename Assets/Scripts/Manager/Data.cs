using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Data
{

}

[Serializable]
class DataSave
{
    public int blood, money, reputation;
    public int dia, habitaciones;
    public int habitacionesDisponibles;
    public int h4, h5, h6, h7, h8, h9,h10,h11,h12;
    public int h1Nights, h2Nights, h3Nights, h4Nights, h5Nights, h6Nights, h7Nights, h8Nights, h9Nights, h10Nights, h11Nights, h12Nights;
    public int h1ID, h2ID, h3ID, h4ID, h5ID, h6ID, h7ID, h8ID, h9ID, h10ID, h11ID, h12ID;
    public int piso3, piso4;
    public int basura1, basura2, basura3, basura4;
    public int[] habitacionID = new int[12];
}
