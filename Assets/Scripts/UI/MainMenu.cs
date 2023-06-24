using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Manager manager;
    public TextMeshProUGUI tMPro;
    public string primeraEscena;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.Cargar();
        tMPro.text = ":" + manager.noche;
    }

    public void ChangeScene()
    {
        if(manager.noche == 0)
        {
            SceneManager.LoadScene(primeraEscena, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Recepcion", LoadSceneMode.Single);
        }
    }

    public void NewGame()
    {
        manager.Restart();
        SceneManager.LoadScene(primeraEscena, LoadSceneMode.Single);
    }
}
