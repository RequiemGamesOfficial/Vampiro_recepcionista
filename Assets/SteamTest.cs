using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTest : MonoBehaviour
{
    public bool notConnected;

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

    void FixedUpdate()
    {
        Steamworks.SteamClient.RunCallbacks();
    }

    private void PrintYourName()
    {
        Debug.Log("Steam ID:" + Steamworks.SteamClient.Name);
    }

    void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
#endif
}
