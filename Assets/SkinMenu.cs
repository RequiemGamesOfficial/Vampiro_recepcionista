using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinMenu : MonoBehaviour
{
    public bool active;
    public Animator selectSkin;

    public void ShowHideMenu()
    {
        active = !active;
        if (active)
        {
            selectSkin.Play("Normal");
        }
        else
        {
            selectSkin.Play("Show");
        }
    }


}
