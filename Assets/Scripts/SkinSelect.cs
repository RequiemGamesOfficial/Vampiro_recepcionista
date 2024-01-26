using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    Manager manager;
    public int skin;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
    public void Skin0()
    {
        if (manager.huespedDead[0] >= 1)
        {
            skin = 1;
        }
    }
    public void Skin1()
    {
        if (manager.huespedDead[1] >= 1)
        {
            skin = 2;
        }
    }
    public void Skin2()
    {
        if (manager.huespedDead[2] >= 1)
        {
            skin = 3;
        }
    }
    public void Skin3()
    {
        if (manager.huespedDead[3] >= 1)
        {
            skin = 4;
        }
    }
    public void Skin4()
    {
        if (manager.huespedDead[4] >= 1)
        {
            skin = 5;
        }
    }
    public void Skin5()
    {
        if (manager.huespedDead[5] >= 1)
        {
            skin = 6;
        }
    }
    public void Skin6()
    {
        if (manager.huespedDead[6] >= 1)
        {
            skin = 7;
        }
    }
    public void Skin7()
    {
        if (manager.huespedDead[7] >= 1)
        {
            skin = 8;
        }
    }
    public void Skin8()
    {
        if (manager.huespedDead[8] >= 1)
        {
            skin = 9;
        }
    }
    public void Skin9()
    {
        if (manager.huespedDead[9] >= 1)
        {
            skin = 10;
        }
    }
    public void Skin10()
    {
        if (manager.huespedDead[10] >= 1)
        {
            skin = 11;
        }
    }
    public void Skin11()
    {
        if (manager.huespedDead[11] >= 1)
        {
            skin = 12;
        }
    }
    public void Skin12()
    {
        if (manager.huespedDead[12] >= 1)
        {
            skin = 13;
        }
    }
    public void Skin13()
    {
        if (manager.huespedDead[13] >= 1)
        {
            skin = 14;
        }
    }
    public void Skin14()
    {
        if (manager.huespedDead[14] >= 1)
        {
            skin = 15;
        }
    }
    public void Skin15()
    {
        if (manager.huespedDead[15] >= 1)
        {
            skin = 16;
        }
    }
    public void Skin16()
    {
        if (manager.huespedDead[16] >= 1)
        {
            skin = 17;
        }
    }
    public void Skin17()
    {
        if (manager.huespedDead[17] >= 1)
        {
            skin = 18;
        }
    }
    public void Skin18()
    {
        if (manager.huespedDead[18] >= 1)
        {
            skin = 19;
        }
    }
    public void Skin19()
    {
        if (manager.huespedDead[19] >= 1)
        {
            skin = 20;
        }
    }
    public void Skin20()
    {
        if (manager.huespedDead[20] >= 1)
        {
            skin = 21;
        }
    }
}
