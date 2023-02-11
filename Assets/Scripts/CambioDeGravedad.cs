using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeGravedad : MonoBehaviour
{
    public float gravedad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("CambioDeGravedad", gravedad);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("RestablecerGravedad");
        }
    }
}
