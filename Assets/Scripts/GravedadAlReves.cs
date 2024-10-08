using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadAlReves : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().marciano = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().marciano = false;
            collision.SendMessage("RestablecerGravedadAlReves");
        }
    }
}
