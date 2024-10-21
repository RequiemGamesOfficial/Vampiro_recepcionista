using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engranaje : MonoBehaviour
{
    public int powerRotation = 30;
    public bool active = true;

    void Update()
    {
        if (active)
        {
            transform.Rotate(0, 0, powerRotation * Time.deltaTime);
        }
    }

    public void TriggerAction()
    {
        Alternate();
    }
    public void TriggerAction2()
    {
        Alternate();
    }
    //Alterna de abierto y cerrado
    public void Alternate()
    {
        active = true;
        powerRotation *= -1;
        Invoke("SetOff", 4);
    }

    void SetOff()
    {
        active = false;
    }
}
