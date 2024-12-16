using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogroManager : MonoBehaviour
{

    SteamAchievement steamAchievement;
    public string achievementID;

    private void Start()
    {
        steamAchievement = GameObject.FindGameObjectWithTag("Manager").GetComponent<SteamAchievement>();
    }

    public void SetUnlockAchievement(string achievement)
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        // Steam logros
        steamAchievement.UnlockAchievement(achievement);
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif
    }


    public void UnlockAchievement()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        // Steam logros
        steamAchievement.UnlockAchievement(achievementID);
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif
    }
}
