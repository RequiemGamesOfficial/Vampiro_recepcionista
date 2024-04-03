using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject pixelObject;

    public int gridSize = 100;

    public List<SpriteRenderer> pixels;

    public List<Color> saveColours;

    public Color currentColor = Color.black;


    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        pixels = new List<SpriteRenderer>();

        for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                GameObject obj = Instantiate(pixelObject, new Vector3(i, j, 0), Quaternion.identity, transform);
                pixels.Add(obj.GetComponent<SpriteRenderer>());
            }
        }

    }

    public void SaveGrid()
    {
        saveColours = new List<Color>();
        for (int i = 0; i < pixels.Count; i++)
        {
            saveColours.Add(pixels[i].color);
        }
        SaveColors();
    }

    private void SaveColors()
    {
        // Convertir la lista de colores a una lista de cadenas
        List<string> colorStrings = new List<string>();
        foreach (Color color in saveColours)
        {
            colorStrings.Add(ColorUtility.ToHtmlStringRGBA(color));
        }

        // Guardar la lista de cadenas en PlayerPrefs
        PlayerPrefs.SetString("SavedColors", string.Join(",", colorStrings.ToArray()));
        PlayerPrefs.Save();
    }

    public void LoadColors()
    {
        // Cargar la lista de cadenas de PlayerPrefs
        string savedColors = PlayerPrefs.GetString("SavedColors", "");
        string[] colorStrings = savedColors.Split(',');

        // Convertir las cadenas a colores y agregarlas a la lista finalColours
        foreach (string colorString in colorStrings)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString("#" + colorString, out color))
            {
                saveColours.Add(color);
            }
        }

        for (int i = 0; i < pixels.Count; i++)
        {
            pixels[i].color = saveColours[i];
        }
    }

    public void SetPencilColour(Image thisColour)
    {
        currentColor = thisColour.color;
    }

    public Color GetCurrentColour()
    {
        return currentColor;
    }
}
