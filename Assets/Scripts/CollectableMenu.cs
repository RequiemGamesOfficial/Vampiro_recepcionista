using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableMenu : MonoBehaviour
{
    Manager manager;
    public GameObject[] icon = new GameObject[20];
    public TextMeshProUGUI[] noDead = new TextMeshProUGUI[20];

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void Start()
    {
        Debug.Log("actualizar menu de colleccionable");
        CollectableUpdate();

    }

    void CollectableUpdate()
    {
        for (int i = 0; i < manager.huespedDead.Length; i++)
        {
            if (manager.huespedDead[i] >= 1)
            {
                icon[i].SetActive(true);
                noDead[i].text = ""+manager.huespedDead[i];
            }
        }
    }
}
