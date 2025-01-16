using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformMove : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformMove"))
        {
            Debug.Log("platformParent");
            player.transform.parent = collision.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformMove"))
        {
            player.transform.parent = null;
        }

    }
}
