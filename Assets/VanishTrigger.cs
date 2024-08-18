using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishTrigger : MonoBehaviour
{
    public Animator anim;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("vanish", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("vanish", false);
    }
}
