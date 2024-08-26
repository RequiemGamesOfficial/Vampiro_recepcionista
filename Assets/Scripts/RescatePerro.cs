using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescatePerro : MonoBehaviour
{
    public GameObject perro,portal,particule;
    public Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.pet = 1;
        manager.Guardar();
        Instantiate(particule);
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
