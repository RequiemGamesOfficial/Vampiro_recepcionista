using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Manager manager;
    public ChangeLook changeLook;
    public TextMeshProUGUI nightText,scoreText;
    public string primeraEscena;
    public GameObject trancisionEfect;
    public GameObject buttonContainer;
    public GameObject tutorialSave;
    public GameObject buttonPlay,demoText;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.Cargar();
        changeLook.SetPlayerSkin();
        nightText.text = ":" + manager.noche;
        scoreText.text = ":" + manager.nocheScore;
        if (manager.demo)
        {
            demoText.SetActive(true);
        }
        if (manager.tutoSave <= 0)
        {
            tutorialSave.SetActive(true);
        }
        if(manager.noche <= 0)
        {
            buttonPlay.SetActive(false);
        }
    }

    public void ChangeScene()
    {
        trancisionEfect.SetActive(true);
        buttonContainer.SetActive(false);
        Invoke("LoadScene", 1.5f);
    }
    public void LoadScene()
    {
        if (manager.noche <= 0)
        {
            NewGame();
        }
        else
        {
            SceneManager.LoadScene("Recepcion", LoadSceneMode.Single);
        }
    }

    public void NewGame()
    {
        manager.Restart();
        Invoke("LoadNewGame", 1.5f);
        if (trancisionEfect != null)
        {
            trancisionEfect.SetActive(true);
        }
        if (buttonContainer != null)
        {
            buttonContainer.SetActive(false);
        }
    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene(primeraEscena);
    }
    public void ResetGame()
    {
        manager.RestartGame();
        Invoke("LoadMenu", 1.5f);
        if(trancisionEfect != null)
        {
            trancisionEfect.SetActive(true);
        }
        if(buttonContainer != null)
        {
            buttonContainer.SetActive(false);
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
