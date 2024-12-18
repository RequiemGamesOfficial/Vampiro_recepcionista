using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animator anim;
    public string animationToPlay;

    public void PlayNewAnimation(string newAnimation)
    {
        anim.Play(newAnimation);
    }
}
