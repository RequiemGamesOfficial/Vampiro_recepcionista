using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageKill : MonoBehaviour
{
    public bool destroyObject = true;
    public bool destroyTimer = false;
    public bool intaKill;
    public float destroyTime;
    float timer;

    private void Update()
    {
        if (destroyTimer)
        {
            timer += Time.deltaTime;
            if (timer >= destroyTime)
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
            if (intaKill)
            {
                collision.gameObject.GetComponent<VidasHabitacion>().DamageInstaKill(contactPoint);
            }
            else
            {
                collision.gameObject.GetComponent<VidasHabitacion>().DamageKill(contactPoint);
            }
            if (destroyObject)
            {
                Destroy(gameObject);
            }
        }
    }
}
