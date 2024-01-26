using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTutorial : MonoBehaviour
{
    public string text;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pet"))
        {
            collision.SendMessage("SetDialog", text);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pet"))
        {
            collision.SendMessage("SetDialogOff");
            Destroy(gameObject);
        }
    }
}
