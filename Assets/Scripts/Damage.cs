using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool destroyObject = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            collision.GetContacts(contacts);
            var contactPoint = contacts[0].point;
            collision.gameObject.GetComponent<VidasHabitacion>().Damage(contactPoint);
            //collision.SendMessage("Damage");
            if (destroyObject)
            {
                Destroy(gameObject);
            }           
        }
    }

}
