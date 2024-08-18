using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    Manager manager;
    public string levelChange;
    public string cinematicaPolicia;
    public string cinematicaDemo = "CinematicaDemo";
    public GameObject trancision;
    bool detected;
    public bool pressE = true;
    public GameObject accidentPanel;

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
    public void ChecarAccidentes()
    {
        if (manager.noche > 4)
        {
            //Activar AccidentPanel
            accidentPanel.SetActive(true);
        }
        else
        {
            LoadLevel();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected && pressE)
        {
            ChangeSceneTrigger();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
        }
    }

    void ChangeSceneTrigger()
    {
        if(manager.demo && manager.noche >= 10)
        {
            //Cargar escena final de demo
            Time.timeScale = 1;
            SceneManager.LoadScene(cinematicaDemo, LoadSceneMode.Single);
        }
        else
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
}
