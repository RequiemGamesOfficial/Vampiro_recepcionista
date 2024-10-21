using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactita : MonoBehaviour
{
    public Rigidbody2D rb2d; 
    public LayerMask playerLayer; 
    public float detectionRadius = 1.0f; // Radio de detección debajo de la estalactita
    public float posYOffset;

    private bool hasFallen = false;

    void Update()
    {
        // Revisar si el jugador está debajo usando un círculo de detección
        Collider2D playerDetected = Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y + posYOffset), detectionRadius, playerLayer);

        if (playerDetected && !hasFallen)
        {
            // Cambiar el Rigidbody2D a Dynamic para que caiga
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            hasFallen = true; // Para que no vuelva a activarse
        }
    }

    // Visualización del área de detección en la escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + posYOffset), detectionRadius);
    }
}
