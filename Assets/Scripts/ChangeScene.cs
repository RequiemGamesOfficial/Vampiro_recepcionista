using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    Manager manager;
    public string levelChange;
    public string cinematicaPolicia;
    public GameObject trancision;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
    public void LoadLevel()
    {
        if(trancision != null)
        {
            trancision.SetActive(true);
            Invoke("ChangeSceneTrigger", 1.5f);
        }
        else
        {
            ChangeSceneTrigger();
        }
    }

    void ChangeSceneTrigger()
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
