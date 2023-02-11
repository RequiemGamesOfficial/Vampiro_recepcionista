using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLoss : MonoBehaviour
{
    public Manager manager;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        if(manager.noche <= 2)
        {
            manager.blood -= 10;
        }
        else
        {
            if (manager.noche >=5)
            {
                manager.blood -= 20;
            }
            else
            {
                manager.blood -= 15;
            }            
        }

        if (manager.blood <= 0)
        {
            anim.SetBool("dead", true);
        }
    }
}
