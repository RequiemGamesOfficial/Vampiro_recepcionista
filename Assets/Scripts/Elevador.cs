using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public float velY;
    Rigidbody2D rb;
    Transform cameraPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7.5f);
        cameraPos = Camera.main.transform;
    }

    void Update()
    {
        rb.velocity = new Vector2(0, velY);
        float dist = Vector3.Distance(this.transform.position, cameraPos.position);
        if(dist >= 25)
        {
            Destroy(gameObject);
        }
    }
}
