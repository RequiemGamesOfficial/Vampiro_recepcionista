using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolutionDropdown; // Tu TMP_Dropdown para las resoluciones
    private Resolution[] resolutions; // Resoluciones del dispositivo
    private int currentResolutionIndex = 0;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResolucion();
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        // Obtenemos las resoluciones disponibles del dispositivo
        resolutions = Screen.resolutions;

        // Limpiamos el TMP_Dropdown antes de agregar opciones nuevas
        resolutionDropdown.ClearOptions();

        // Lista para almacenar las opciones
        List<string> options = new List<string>();

        // Usamos un HashSet para eliminar resoluciones duplicadas
        HashSet<string> uniqueResolutions = new HashSet<string>();

        // Recorremos las resoluciones y las agregamos si son �nicas
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if (uniqueResolutions.Add(option)) // Solo si es nueva, la agregamos
            {
                options.Add(option);

                // Si esta es la resoluci�n actual de la pantalla, guardamos el �ndice
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
        }

        // A�adimos las opciones al TMP_Dropdown
        resolutionDropdown.AddOptions(options);

        // Establecemos la resoluci�n actual como la opci�n seleccionada
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Aplicamos la resoluci�n guardada en PlayerPrefs (si la hay)
        resolutionDropdown.value = PlayerPrefs.GetInt("numeroResolucion", currentResolutionIndex);
    }

    public void CambiarResolucion(int resolutionIndex)
    {
        // Actualizamos la resoluci�n seleccionada
        string[] dimensions = resolutionDropdown.options[resolutionIndex].text.Split('x');
        int width = int.Parse(dimensions[0].Trim());
        int height = int.Parse(dimensions[1].Trim());

        // Aplicamos la resoluci�n
        Screen.SetResolution(width, height, Screen.fullScreen);

        // Guardamos la selecci�n en PlayerPrefs
        PlayerPrefs.SetInt("numeroResolucion", resolutionIndex);
    }
}
