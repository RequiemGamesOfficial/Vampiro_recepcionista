using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescatePerro : MonoBehaviour
{
    public GameObject perro,portal,particule;
    GameObject managerObject;
    SteamAchievement steamAchievement;
    public Manager manager;

    private void Start()
    {
        managerObject = GameObject.FindGameObjectWithTag("Manager");
        steamAchievement = managerObject.GetComponent<SteamAchievement>();
        manager = managerObject.GetComponent<Manager>();
        manager.pet = 1;
        manager.Guardar();
        Instantiate(particule);

#if UNITY_STANDALONE || UNITY_EDITOR
        // Steam logros
        steamAchievement.UnlockAchievement("PUPPY_RESCUE");
#elif UNITY_ANDROID
    // Google Play logros
    Debug.Log("Desbloquear logro en Google Play");
#elif UNITY_IOS
    // Game Center logros
    Debug.Log("Desbloquear logro en Game Center");
#endif
    }

    public void ActivarPerro()
    {
        perro.SetActive(true);
    }

    public void ActivarPortal()
    {
        portal.SetActive(true);
        Destroy(gameObject);
    }
}
