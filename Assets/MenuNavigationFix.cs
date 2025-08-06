using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuNavigationFix : MonoBehaviour
{
    public GameObject defaultButton; // El botón inicial al que se le da foco

    void OnEnable()
    {
        // Solo si no hay nada seleccionado
        if (EventSystem.current.currentSelectedGameObject == null || !EventSystem.current.currentSelectedGameObject.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }

    void Update()
    {
        // Si se pierde la selección por error, la restauramos
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }
}
