using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public float speed;
    public float tiempoDeVida; 
    public bool moving;
    public GameObject objetoPadre;

    private void Start()
    {
        Destroy(objetoPadre, tiempoDeVida);
    }

    private void Update()
    {
        if (moving)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    public void ChangeDirection()
    {
        speed *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }

}
