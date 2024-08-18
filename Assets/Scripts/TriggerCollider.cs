using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public GameObject gameObjectToSetActive;
    public bool exit = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObjectToSetActive != null)
        {
            gameObjectToSetActive.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && exit && gameObjectToSetActive !=null)
        {
            gameObjectToSetActive.SetActive(false);
        }
    }
}
