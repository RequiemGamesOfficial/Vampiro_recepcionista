using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D punto in collision.contacts)
            {
                if (punto.normal.y <= -0.9)
                {
                    collision.gameObject.SendMessage("Bouncing");
                    if (anim != null)
                    {
                        anim.Play("Bouncing");
                    }
                }
            }
        }
    }
}
