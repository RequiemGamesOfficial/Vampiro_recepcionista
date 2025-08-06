using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel,fondo;

    bool pausedGame;

    public GameObject buttonSelect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyUp(KeyCode.JoystickButton7))
        {            
            if (pausedGame)
            {               
                ResumeGame();
            }
            else
            {               
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausedGame = true;
        pauseMenuPanel.SetActive(true);
        fondo.SetActive(true);
        Time.timeScale = 0;
        buttonSelect = EventSystem.current.currentSelectedGameObject;
    }
    public void ResumeGame()
    {
        pausedGame = false;
        pauseMenuPanel.SetActive(false);
        fondo.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
