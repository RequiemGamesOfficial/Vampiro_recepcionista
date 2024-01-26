using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompraAdorno : MonoBehaviour
{
    bool detected;
    public MejoraDoble mejoraDoble;
    public CompraMejora compraMejora;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Debug.Log("Compra con E");
            mejoraDoble.Comprado(true);
            compraMejora.Mejorar();
            //Mejorar();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
        }
    }
}
