using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicBotton : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject dynamicObject;
    public int idbutton = 3;
    public Image buttonIcon;
    public Sprite[] icons;


    public void UpdateButton(GameObject objectD, int id)
    {
        dynamicObject = objectD;
        idbutton = id;
        buttonIcon.sprite = icons[idbutton];      
    }

    public void UseButton()
    {
        //ChangeLocation
        if (idbutton == 0)
        {
            dynamicObject.SendMessage("ChangeFloor");
        }
        //Kill
        if (idbutton == 1)
        {
            dynamicObject.SendMessage("Attack");
        }
        //BuySomething
        if (idbutton == 2)
        {
            dynamicObject.SendMessage("Buying");
        }
    }

    public void PointerDown()
    {
        //Jump
        if (idbutton == 3)
        {
            playerController.ClickJump();
        }
    }
    public void PointerUp()
    {
        //Jump
        if (idbutton == 3)
        {
            playerController.ReleaseJump();
        }
    }

    public void ResetButton()
    {
        idbutton = 3;
        dynamicObject = null;
        buttonIcon.sprite = icons[3];
    }


}
