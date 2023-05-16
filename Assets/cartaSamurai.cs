using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaSamurai : MonoBehaviour
{
    bool detected;
    public GameObject button, cartaUI;
    public GameObject samurai;

    bool samuraiBool;
    public bool dead;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            LeerCarta();
        }
    }
    public void RestartDead()
    {
        Debug.Log("RestartDead");
        dead = false;

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

    public void LeerCarta()
    {
        if (!samuraiBool)
        {
            Instantiate(samurai);            
            samuraiBool = true;
        }
        cartaUI.SetActive(true);
    }
}
