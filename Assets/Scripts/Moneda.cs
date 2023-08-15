using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : MonoBehaviour
{
    Manager manager;
    public Stats stats;
    public int money;

    public GameObject moneyPrefab;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            manager.money += money;
            stats.SetMoney();
            Instantiate(moneyPrefab, new Vector3(this.transform.position.x + .5f, this.transform.position.y - .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(moneyPrefab, new Vector3(this.transform.position.x + 1, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            Instantiate(moneyPrefab, new Vector3(this.transform.position.x - .5f, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            Instantiate(moneyPrefab, this.transform.position, Quaternion.identity);
            manager.Guardar();
            Destroy(this.gameObject);
        }
    }
}
