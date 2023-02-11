using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilPayaso : MonoBehaviour
{

    float z;
    public float velocidadRotacion;
    public float velX;
    Rigidbody2D rb;
    bool up = true;
    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = Random.Range(5f, 12f);
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        z += Time.deltaTime * velocidadRotacion;
        transform.rotation = Quaternion.Euler(0, 0, z);
        rb.velocity = new Vector2(velX, timer);

        if (up)
        {
            timer -= Time.deltaTime * 4;
            if(timer <= 0)
            {
                up = false;
                timer = 0;
            }
        }

    }
}
