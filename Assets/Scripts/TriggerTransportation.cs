using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransportation : MonoBehaviour
{
    public string childrenTag = "Player";
    GameObject newChildren;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(childrenTag))
        {
            Debug.Log("Trasportation");
            newChildren = collision.gameObject;
            newChildren.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(childrenTag))
        {
            if (newChildren != null)
            {
                Debug.Log("TrasportationOff");
                newChildren.transform.parent = null;
            }
        }
    }

    public void ParentOff()
    {
        if(newChildren != null)
        {
            Debug.Log("TrasportationOff");
            newChildren.transform.parent = null;
        }
    }
}
