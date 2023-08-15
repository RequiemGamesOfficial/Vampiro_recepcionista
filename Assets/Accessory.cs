using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    public AccessoryManager accessoryManager;
    public GameObject accesoryPrefab;
    bool detected;
    public GameObject button;
    public int id;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            UseAccesory();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            button.SetActive(false);
        }
    }

    public void UseAccesory()
    {
        //ponerlo en el jugador
        accessoryManager.CreateAccessory(accesoryPrefab,id);
    }
}
