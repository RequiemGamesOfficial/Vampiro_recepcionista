using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    Manager manager;
    public string levelChange;
    public string cinematicaPolicia;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
    public void LoadLevel()
    {
        if (manager.reputation <= 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(cinematicaPolicia, LoadSceneMode.Single);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(levelChange, LoadSceneMode.Single);
        }       
    }
}
