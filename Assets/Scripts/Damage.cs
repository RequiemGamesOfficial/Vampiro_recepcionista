using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool destroyObject = true;
    public bool destroyTimer = false;
    public float destroyTime;
    public bool destroyInFloor;
    float timer;
    public bool instaKill;
    public bool boss;
    public GameObject particle;

    private void Update()
    {
        if (destroyTimer)
        {
            timer += Time.deltaTime;
            if(timer >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            collision.GetContacts(contacts);
            var contactPoint = contacts[0].point;
            if (boss)
            {
                collision.gameObject.GetComponent<VidasBoss>().Damage(contactPoint);
            }
            else
            {
                if (instaKill)
                {
                    collision.gameObject.GetComponent<VidasHabitacion>().DamageKill(contactPoint);
                }
                else
                {
                    if(particle != null)
                    {
                        Instantiate(particle, this.transform.position, Quaternion.identity);
                    }                    
                    collision.gameObject.GetComponent<VidasHabitacion>().Damage(contactPoint);
                }                
            }           
            //collision.SendMessage("Damage");
            if (destroyObject)
            {
                Destroy(gameObject);
            }           
        }

        if (collision.gameObject.CompareTag("Floor") && destroyInFloor)
        {
            if (particle != null)
            {
                Instantiate(particle, this.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
