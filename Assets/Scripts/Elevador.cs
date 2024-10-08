using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public float velY,velX;
    Rigidbody2D rb;
    Transform cameraPos;
    public float timeToDestroy = 7.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
        cameraPos = Camera.main.transform;
    }

    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        float dist = Vector3.Distance(this.transform.position, cameraPos.position);
        if(dist >= 25)
        {
            Destroy(gameObject);
        }
    }
}
