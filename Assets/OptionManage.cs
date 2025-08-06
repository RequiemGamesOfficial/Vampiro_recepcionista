using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class OptionManage : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject newSelectedButton;
    public GameObject optionSelectedButton;

    public void DisableOptionMenu()
    {
        // 1. Cambiar selección
        EventSystem.current.SetSelectedGameObject(newSelectedButton);

        // 2. Ahora desactivar el otro botón
        optionMenu.SetActive(false);
    }
    public void EnableOptionMenu()
    {   
        optionMenu.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(optionSelectedButton);
    }
}
