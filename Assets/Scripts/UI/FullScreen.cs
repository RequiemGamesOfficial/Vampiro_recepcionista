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

        // Variable temporal para encontrar la resoluci�n guardada
        int savedResolutionIndex = PlayerPrefs.GetInt("numeroResolucion", -1);
        bool isResolutionSaved = false;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if (uniqueResolutions.Add(option)) // Solo si es nueva, la agregamos
            {
                options.Add(option);

                // Si la resoluci�n coincide con la guardada, tomamos el �ndice
                if (savedResolutionIndex == -1 && resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }

                // Si encontramos la resoluci�n guardada
                if (i == savedResolutionIndex)
                {
                    currentResolutionIndex = i;
                    isResolutionSaved = true;
                }
            }
        }

        // Si no hab�a resoluci�n guardada, usamos la resoluci�n actual del monitor
        if (!isResolutionSaved)
        {
            PlayerPrefs.SetInt("numeroResolucion", currentResolutionIndex);
        }

        // A�adimos las opciones al TMP_Dropdown
        resolutionDropdown.AddOptions(options);

        // Establecemos la resoluci�n guardada como la opci�n seleccionada
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
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
        PlayerPrefs.Save(); // Asegura que se guarde inmediatamente
    }
}
