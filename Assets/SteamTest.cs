using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SteamTest : MonoBehaviour
{
    public bool notConnected;
    public TMP_Text textMeshProText;

#if UNITY_STANDALONE || UNITY_EDITOR
    void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(2882380); // Reemplaza con tu AppID de Steam
            PrintYourName();
        }
        catch (System.Exception e)
        {
            notConnected = true;
            Debug.Log(e);
        }
    }

    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }

    private void PrintYourName()
    {
        Debug.Log("Steam ID:" + Steamworks.SteamClient.Name);
        if(textMeshProText != null)
        {
            textMeshProText.text = ("Steam ID:" + Steamworks.SteamClient.Name);
        }
    }

    void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
#endif
}
