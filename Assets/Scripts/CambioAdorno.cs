using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAdorno : MonoBehaviour
{
    bool detected;
    public MejoraDoble mejoraDoble;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Debug.Log("Compra con E");
            mejoraDoble.Cambio();
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
