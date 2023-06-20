using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : MonoBehaviour
{
    Manager manager;
    public int money;
    public Text moneyText;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            manager.money += money;
            moneyText.text = "$" + manager.money;
            manager.Guardar();
            Destroy(this.gameObject);
        }
    }
}
