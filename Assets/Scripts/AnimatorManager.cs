using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator anim;
    public string animation01,animation02;

    public void PlayAnimation1()
    {
        anim.Play(animation01);
    }

    public void PlayAnimation2()
    {
        anim.Play(animation02);
    }
}
