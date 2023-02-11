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
    public int h4, h5, h6, h7, h8, h9,h10,h11,h12;
    public int piso3, piso4;
    public int basura1, basura2, basura3, basura4;
}
