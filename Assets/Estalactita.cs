using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactita : MonoBehaviour
{
    public Rigidbody2D rb2d; 
    public LayerMask playerLayer; 
    public float detectionRadius = 1.0f; // Radio de detecci�n debajo de la estalactita
    public float posYOffset;

    private bool hasFallen = false;

    void Update()
    {
        // Revisar si el jugador est� debajo usando un c�rculo de detecci�n
        Collider2D playerDetected = Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y + posYOffset), detectionRadius, playerLayer);

        if (playerDetected && !hasFallen)
        {
            // Cambiar el Rigidbody2D a Dynamic para que caiga
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            hasFallen = true; // Para que no vuelva a activarse
        }
    }

    // Visualizaci�n del �rea de detecci�n en la escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + posYOffset), detectionRadius);
    }
}
