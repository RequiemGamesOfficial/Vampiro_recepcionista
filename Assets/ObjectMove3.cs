using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove3 : MonoBehaviour
{
    public GameObject objetcToMove;
    public SpriteRenderer spriteRenderer;
    public Transform point1,point2,point3;

    public float velocity;
    private Vector3 moveTo;

    void Start()
    {
        moveTo = point2.position;
    }

    void Update()
    {
        if (objetcToMove.transform.position == point2.position)
        {
            moveTo = point3.position;
            //Cambiar Yflip
            if (spriteRenderer != null)
            {
                spriteRenderer.flipY = true;
            }
        }

        if (objetcToMove.transform.position == point3.position)
        {
            moveTo = point1.position;
            if (spriteRenderer != null)
            {
                spriteRenderer.flipY = false;
            }
        }

        if (objetcToMove.transform.position == point1.position)
        {
            moveTo = point2.position;
            if (spriteRenderer != null)
            {
                spriteRenderer.flipY = false;
            }
        }

        objetcToMove.transform.position = Vector3.MoveTowards(objetcToMove.transform.position, moveTo, velocity * Time.deltaTime);
    }
}
