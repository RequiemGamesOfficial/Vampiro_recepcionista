using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public Rigidbody2D rgb2D;
    bool kinematic,taken;
    float timer,timerDestroy;


    private void Update()
    {
        if (kinematic)
        {
            timer += Time.deltaTime;
            if(timer >= 0.6f)
            {
                timer = 0;
                kinematic = false;
                rgb2D.velocity = new Vector2(0, 0);
                rgb2D.bodyType = RigidbodyType2D.Kinematic;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        if (!taken)
        {
            timerDestroy += Time.deltaTime;
            if(timerDestroy >= 4)
            {
                Destroy(gameObject);
            }
        }
    }

    public void KinematicBody(Transform charola)
    {
        kinematic = true;
        taken = true;
        transform.position = new Vector3(charola.position.x, transform.position.y, 0);
        transform.rotation = new Quaternion(0, 0, 0,0);       
    }

    public void DynamicBody()
    {
        rgb2D.bodyType = RigidbodyType2D.Dynamic;
        kinematic = false;
        taken = false;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
