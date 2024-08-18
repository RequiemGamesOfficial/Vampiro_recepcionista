using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeGravedad : MonoBehaviour
{
    public bool water;
    public float gravedad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().CambioDeGravedad(gravedad, water);
        }

        if (collision.CompareTag("Pet"))
        {
            collision.GetComponent<FollowPlayer>().CambioDeGravedad(gravedad, water);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("RestablecerGravedad",water);
        }

        if (collision.CompareTag("Pet"))
        {
            collision.SendMessage("RestablecerGravedad", water);
        }
    }
}
