using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelChange;

    public void LoadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelChange, LoadSceneMode.Single);
    }
}
