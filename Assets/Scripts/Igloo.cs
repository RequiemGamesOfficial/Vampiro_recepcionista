using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igloo : MonoBehaviour
{
    public GameObject penguin;
    public float castTime;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= castTime)
        {
            Instantiate(penguin);
            timer = 0;
        }
    }

}
