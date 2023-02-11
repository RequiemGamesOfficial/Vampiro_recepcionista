using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilPadrecito : MonoBehaviour
{
    Rigidbody2D rb;
    float velX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velX = Random.Range(-200f, 200f);

        rb.AddForce(transform.up * 200);
        rb.AddForce(transform.right * velX);

        Destroy(gameObject, 8);
    }

}
