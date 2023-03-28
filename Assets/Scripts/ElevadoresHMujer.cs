using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadoresHMujer : MonoBehaviour
{
    public Transform point1, point2, point3;
    public GameObject elevatorUp, elevatorDown;

    public float timer,tCreateElevator;

    private void Start()
    {
        CreateElevators();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= tCreateElevator)
        {
            CreateElevators();
            timer = 0;
        }
    }

    void CreateElevators()
    {
        Instantiate(elevatorUp, point1.position, Quaternion.identity);
        Instantiate(elevatorDown, point2.position, Quaternion.identity);
        Instantiate(elevatorUp, point3.position, Quaternion.identity);
    }
}
