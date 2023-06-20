using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaRayos : MonoBehaviour
{
    public Animator rayoAnimator;
    [Range (3,6)]
    public float timeToSpend = 3f;
    float timer;
    public bool random;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeToSpend)
        {
            if (!random)
            {
                rayoAnimator.Play("Rayo");
                timer = 0;
            }
            else
            {
                int randonNumber = Random.Range(1, 3);
                if(randonNumber == 2)
                {
                    rayoAnimator.Play("Rayo");
                    timer = 0;
                    print("YES"+ randonNumber);
                }
                else
                {
                    timer = 0;
                    print("NO" + randonNumber);
                }
            }           
        }
    }
}
