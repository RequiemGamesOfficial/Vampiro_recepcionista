using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHabitacion : MonoBehaviour
{
    VidasHabitacion vidasHabitacion;
    public Transform door;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            collision.GetContacts(contacts);
            var contactPoint = contacts[0].point;
            vidasHabitacion = collision.gameObject.GetComponent<VidasHabitacion>();
            vidasHabitacion.Damage(contactPoint);
            if(vidasHabitacion.vidas >= 1)
            {
                collision.gameObject.transform.position = door.position;
            }
        }
    }
}
