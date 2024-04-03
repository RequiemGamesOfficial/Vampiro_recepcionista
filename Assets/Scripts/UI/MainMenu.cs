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
    public GameObject trancisionEfect;
    public GameObject buttonContainer;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.Cargar();
        tMPro.text = ":" + manager.noche;
    }

    public void ChangeScene()
    {
        trancisionEfect.SetActive(true);
        buttonContainer.SetActive(false);
        Invoke("LoadScene", 1.5f);
    }
    void LoadScene()
    {
        if (manager.noche == 0)
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
        trancisionEfect.SetActive(true);
        buttonContainer.SetActive(false);
        Invoke("LoadNewGame", 1.5f);
    }
    void LoadNewGame()
    {
        SceneManager.LoadScene(primeraEscena, LoadSceneMode.Single);
    }
}
