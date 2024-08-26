using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectableStartMenu : MonoBehaviour
{
    Manager manager;
    public GameObject[] icon = new GameObject[20];
    public TextMeshProUGUI[] noDead = new TextMeshProUGUI[20];
    public Slider[] slider = new Slider[20];
    public GameObject[] contorno = new GameObject[20];

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
        for (int i = 0; i < manager.globalDead.Length; i++)
        {
            if (manager.globalDead[i] >= 1)
            {
                icon[i].SetActive(true);
                noDead[i].text = "" + manager.globalDead[i];              
                slider[i].value = manager.globalDead[i];
                if(manager.globalDead[i] >= 5)
                {
                    contorno[i].SetActive(true);
                }
            }

        }
    }
}
