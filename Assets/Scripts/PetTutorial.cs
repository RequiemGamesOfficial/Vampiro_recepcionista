using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class PetTutorial : MonoBehaviour
{
    public LocalizeStringEvent stringEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pet"))
        {
            collision.SendMessage("SetDialog");
            stringEvent.enabled = true;
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
