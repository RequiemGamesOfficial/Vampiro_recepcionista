using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playoncollision : MonoBehaviour
{
    public SoundRandomAnimator soundrandomanimator; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         soundrandomanimator.PlayRandomSound();

        }
    }
}
