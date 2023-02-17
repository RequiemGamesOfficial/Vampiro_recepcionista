using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    bool pausedGame;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pausedGame = false;
        pauseMenuPanel.SetActive(false);
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
