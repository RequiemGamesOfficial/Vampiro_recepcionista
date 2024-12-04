using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove3 : MonoBehaviour
{
    public GameObject objetcToMove;
    public Transform point1,point2,point3;

    public float rotationSpeed = 5f; // Velocidad de rotación
    public float velocity;
    private Vector3 moveTo;

    void Start()
    {
        moveTo = point2.position;
    }

    void Update()
    {
        // Cambiar la posición objetivo cuando se llega a un punto
        if (Vector3.Distance(objetcToMove.transform.position, point2.position) < 0.1f)
        {
            moveTo = point3.position;
        }
        else if (Vector3.Distance(objetcToMove.transform.position, point3.position) < 0.1f)
        {
            moveTo = point1.position;
        }
        else if (Vector3.Distance(objetcToMove.transform.position, point1.position) < 0.1f)
        {
            moveTo = point2.position;
        }

        // Mover el objeto hacia la posición objetivo
        objetcToMove.transform.position = Vector3.MoveTowards(objetcToMove.transform.position, moveTo, velocity * Time.deltaTime);

        // Rotar el objeto hacia la dirección del objetivo
        Vector3 direction = moveTo - objetcToMove.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle + 90); // Ajusta el -90 según tu sprite
        objetcToMove.transform.rotation = Quaternion.Lerp(objetcToMove.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
