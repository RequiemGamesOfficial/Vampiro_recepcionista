using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixelmanager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Brush"))
        {
            Debug.Log("OnBrush");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Paint");
                spriteRenderer.color = transform.parent.GetComponent<GridManager>().GetCurrentColour();
            }
        }
    }
}
