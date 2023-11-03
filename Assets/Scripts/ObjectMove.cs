using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public GameObject objetcToMove;
    public SpriteRenderer spriteRenderer;
    public Transform startPoint;
    public Transform endPoint;
    public float velocity;
    private Vector3 moveTo;

    void Start()
    {
        moveTo = endPoint.position;
    }

    void Update()
    {
        if (objetcToMove.transform.position == endPoint.position)
        {
            moveTo = startPoint.position;
            //Cambiar Yflip
            spriteRenderer.flipY = true;
        }

        if (objetcToMove.transform.position == startPoint.position)
        {
            moveTo = endPoint.position;
            spriteRenderer.flipY = false;
        }

        objetcToMove.transform.position = Vector3.MoveTowards(objetcToMove.transform.position, moveTo, velocity * Time.deltaTime);
    }
}
