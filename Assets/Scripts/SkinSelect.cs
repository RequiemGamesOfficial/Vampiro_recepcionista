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
        if (manager.globalDead[0] >= 5)
        {
            skin = 1;
        }
    }
    public void Skin1()
    {
        if (manager.globalDead[1] >= 5)
        {
            skin = 2;
        }
    }
    public void Skin2()
    {
        if (manager.globalDead[2] >= 5)
        {
            skin = 3;
        }
    }
    public void Skin3()
    {
        if (manager.globalDead[3] >= 5)
        {
            skin = 4;
        }
    }
    public void Skin4()
    {
        if (manager.globalDead[4] >= 5)
        {
            skin = 5;
        }
    }
    public void Skin5()
    {
        if (manager.globalDead[5] >= 5)
        {
            skin = 6;
        }
    }
    public void Skin6()
    {
        if (manager.globalDead[6] >= 5)
        {
            skin = 7;
        }
    }
    public void Skin7()
    {
        if (manager.globalDead[7] >= 5)
        {
            skin = 8;
        }
    }
    public void Skin8()
    {
        if (manager.globalDead[8] >= 5)
        {
            skin = 9;
        }
    }
    public void Skin9()
    {
        if (manager.globalDead[9] >= 5)
        {
            skin = 10;
        }
    }
    public void Skin10()
    {
        if (manager.globalDead[10] >= 5)
        {
            skin = 11;
        }
    }
    public void Skin11()
    {
        if (manager.globalDead[11] >= 5)
        {
            skin = 12;
        }
    }
    public void Skin12()
    {
        if (manager.globalDead[12] >= 5)
        {
            skin = 13;
        }
    }
    public void Skin13()
    {
        if (manager.globalDead[13] >= 5)
        {
            skin = 14;
        }
    }
    public void Skin14()
    {
        if (manager.globalDead[14] >= 5)
        {
            skin = 15;
        }
    }
    public void Skin15()
    {
        if (manager.globalDead[15] >= 5)
        {
            skin = 16;
        }
    }
    public void Skin16()
    {
        if (manager.globalDead[16] >= 5)
        {
            skin = 17;
        }
    }
    public void Skin17()
    {
        if (manager.globalDead[17] >= 5)
        {
            skin = 18;
        }
    }
    public void Skin18()
    {
        if (manager.globalDead[18] >= 5)
        {
            skin = 19;
        }
    }
    public void Skin19()
    {
        if (manager.globalDead[19] >= 5)
        {
            skin = 20;
        }
    }
    public void Skin20()
    {
        if (manager.globalDead[20] >= 5)
        {
            skin = 21;
        }
    }
}
