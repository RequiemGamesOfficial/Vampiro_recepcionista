using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerZone : MonoBehaviour
{
    public GameObject objetcToActive;
    public string compareTag = "Player";
    public bool changeLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            if (changeLevel)
            {
                objetcToActive.SendMessage("LoadLevel");
            }
            else
            {
                
            }
            //Destroy(gameObject);
        }
    }
}
