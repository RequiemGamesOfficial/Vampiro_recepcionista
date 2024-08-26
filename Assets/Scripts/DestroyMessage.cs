using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMessage : MonoBehaviour
{
    
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void DesactiveGameObjet()
    {
        this.gameObject.SetActive(false);
    }

}
