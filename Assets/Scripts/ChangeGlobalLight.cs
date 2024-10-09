using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ChangeGlobalLight : MonoBehaviour
{
    Light2D globalLight;
    SpriteRenderer spritePlayer;

    private void Start()
    {
        globalLight = GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            globalLight.color = Color.black;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            globalLight.color = Color.white;
            spritePlayer = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
            spritePlayer.sortingLayerName = "Default";
        }
    }


}
