using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSave : MonoBehaviour
{
    public GameObject iconPrefab;

    public void ShowIcon()
    {
        if(iconPrefab != null)
        {
            iconPrefab.SetActive(true);
        }
        else
        {
            Debug.Log("IconPrefab is Null");
        }
    }
}
