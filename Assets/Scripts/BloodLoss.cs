using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLoss : MonoBehaviour
{
    public Manager manager;
    public Animator anim;
    public Stats stats;
    public GameObject[] borde;

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
                //manager.blood -= 20;
                manager.blood -= 15;
            }
            else
            {
                //manager.blood -= 15;
                manager.blood -= 10;
            }            
        }

        if (manager.blood <= 0)
        {
            Debug.Log("Muerte por sangre");
            anim.Play("Dead");
        }

        if (manager.blood <= 20)
        {
            for (int i = 0; i < borde.Length; i++)
            {
                borde[i].SetActive(true);
            }
        }
       
        stats.SetNewBlood();
    }


}
