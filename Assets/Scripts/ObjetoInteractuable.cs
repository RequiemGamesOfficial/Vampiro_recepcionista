using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractuable : MonoBehaviour
{
    bool detected;

    public GameObject gameObjectToEnable;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            Action();
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

    public void Action()
    {
        gameObjectToEnable.SetActive(true);
    }
}
