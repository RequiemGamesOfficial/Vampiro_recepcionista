using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorSotano : MonoBehaviour
{

    public GameObject obetoExtra;
    public Canvas canvasWorld;

    private void Start()
    {
        canvasWorld.worldCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            if (obetoExtra != null)
            {
                obetoExtra.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (obetoExtra != null)
            {
                obetoExtra.SetActive(false);
            }
        }
    }
}
