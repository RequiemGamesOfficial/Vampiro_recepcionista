using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject gameObjectToEnable;

    public void SetEnableObject()
    {
        gameObjectToEnable.SetActive(true);
    }
}
