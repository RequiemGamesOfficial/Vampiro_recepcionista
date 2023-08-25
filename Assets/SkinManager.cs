using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    Manager manager;
    ChangeLook changeLook;
    public GameObject skinSelect;
    public GameObject[] skinButton = new GameObject[16];

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        changeLook = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangeLook>();
        for (int i = 0; i < manager.huespedDead.Length; i++)
        {
            if (manager.huespedDead[i] >= 1)
            {
                skinButton[i].SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinSelect.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinSelect.SetActive(false);
        }
    }

    public void SelectSkinID(int id)
    {
        manager.skin = id;
        changeLook.ChangeAnimatorID(id);
    }
}
