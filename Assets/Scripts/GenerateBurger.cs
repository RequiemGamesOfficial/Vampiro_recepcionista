using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBurger : MonoBehaviour
{
    float timer;
    public GameObject[] ingredient;
    public float minX, maxX, posY;
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
                float randomX = Random.Range(minX, maxX);
                int randomObject = Random.Range(0, ingredient.Length);
                Instantiate(ingredient[randomObject], new Vector3(randomX, posY, 0), Quaternion.identity);
            }
        }
    }

    public void ActiveGenerate(bool activebool)
    {
        active = activebool;
    }
}
