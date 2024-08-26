using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerate : MonoBehaviour
{
    float timer;
    public GameObject spawnItem;
    public Transform[] pointToSpaw;
    public float timeToSpawn = 2;
    public bool active;

    private void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;

            if (timer >= timeToSpawn)
            {
                timer = 0;
                InstantiateObject();
            }
        }
    }

    public void InstantiateObject()
    {
        Debug.Log("Point Spawn Lenght" + pointToSpaw.Length);
        int randonPoint = Random.Range(0, pointToSpaw.Length);
        Debug.Log("Random Spawn Lenght" + randonPoint);
        Instantiate(spawnItem, pointToSpaw[randonPoint].position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveGenerate(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveGenerate(false);
        }
    }

    public void ActiveGenerate(bool activebool)
    {
        active = activebool;
    }
}
