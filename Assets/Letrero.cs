using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letrero : MonoBehaviour
{
    bool detected;
    public GameObject objetosCompra;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            objetosCompra.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            objetosCompra.SetActive(false);
        }
    }
}
