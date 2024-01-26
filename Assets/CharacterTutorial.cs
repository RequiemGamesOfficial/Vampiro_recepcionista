using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTutorial : MonoBehaviour
{
    public Canvas canvasWorld;
    public GameObject gameObjectToSetActive;

    private void Start()
    {
        canvasWorld.worldCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObjectToSetActive.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObjectToSetActive.SetActive(false);
        }
    }
}
