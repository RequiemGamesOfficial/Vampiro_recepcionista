using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    bool pausedGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    public void ExitGame()
    {
        Application.Quit();
    }
}
