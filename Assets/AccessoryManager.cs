using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryManager : MonoBehaviour
{
    GameObject player;
    GameObject accessoryObject;
    public int accessoryid;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CreateAccessory(GameObject prefab, int id)
    {                           
        if(id == accessoryid && accessoryObject != null)
        {
            Debug.Log("es el mismo");
            Destroy(accessoryObject);
            accessoryid = id;
        }
        else
        {
            Debug.Log("NO es el mismo");
            if (accessoryObject != null)
            {
                Destroy(accessoryObject);
            }
            accessoryObject = Instantiate(prefab, player.transform.position, Quaternion.identity);
            accessoryObject.transform.parent = player.transform;
            //Voltear el accesorio a la direccion del jugador
            if(player.transform.localScale.x < 0)
            {
                Vector3 localScale = accessoryObject.transform.localScale;
                localScale.x *= -1f;
                accessoryObject.transform.localScale = localScale;
            }          
            accessoryid = id;
        }     
    }
}
