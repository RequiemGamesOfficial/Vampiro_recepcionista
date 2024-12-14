using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetNewGame : MonoBehaviour
{
    GameObject managerObject;
    SteamAchievement steamAchievement;
    Manager manager;
    public Text textNoche;

    public string logroID;


    void Start()
    {
        managerObject = GameObject.FindGameObjectWithTag("Manager");
        steamAchievement = managerObject.GetComponent<SteamAchievement>();
        manager = managerObject.GetComponent<Manager>();
        textNoche.text = (""+manager.noche);
#if UNITY_STANDALONE || UNITY_EDITOR
        // Steam logros
        if (!string.IsNullOrEmpty(logroID))
        {
            steamAchievement.UnlockAchievement(logroID);
        }
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif

    }

    public void ResetearValores()
    {
        Debug.Log("Resetear");
        manager.Restart();
    }


}
