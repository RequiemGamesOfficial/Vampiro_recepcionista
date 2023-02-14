using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Manager manager;
    public TextMeshProUGUI tMPro;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.Cargar();
        tMPro.text = "Noche:" + manager.noche;
    }

    public void ChangeScene()
    {
        if(manager.noche == 0)
        {
            SceneManager.LoadScene("Cinematica", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Recepcion", LoadSceneMode.Single);
        }
    }

    public void NewGame()
    {
        manager.Restart();
        SceneManager.LoadScene("Cinematica", LoadSceneMode.Single);
    }
}
