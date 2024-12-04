using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToPlayAnim : MonoBehaviour
{

    public Animator anim;
    public string animEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (anim != null)
            {
                anim.Play(animEffect);
            }
        }
    }

    public void PlayAnimation()
    {
        anim.Play(animEffect);
    }
}
