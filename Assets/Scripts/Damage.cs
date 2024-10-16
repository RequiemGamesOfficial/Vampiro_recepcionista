using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool destroyObject = true;
    public bool destroyTimer = false;
    public float destroyTime;
    float timer;
    public bool instaKill;
    public bool boss;

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
                    collision.gameObject.GetComponent<VidasHabitacion>().Damage(contactPoint);
                }                
            }           
            //collision.SendMessage("Damage");
            if (destroyObject)
            {
                Destroy(gameObject);
            }           
        }
    }

}
