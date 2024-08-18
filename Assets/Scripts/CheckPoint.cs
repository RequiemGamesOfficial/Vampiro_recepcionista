using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public DemonBoss demonBoss;
    public GameObject fuegoAzul;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //pasar coordenadas a DemonBoss
            demonBoss.SetCheckpoint(transform.position);
            fuegoAzul.SetActive(true);
        }
    }
}
