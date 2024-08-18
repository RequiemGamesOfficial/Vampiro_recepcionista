using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject objetcToSpawn;
    public GameObject currentObject;
    public string compareTag = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            if(currentObject == null)
            {
                currentObject = Instantiate(objetcToSpawn);
            }           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }          
        }
    }
}
