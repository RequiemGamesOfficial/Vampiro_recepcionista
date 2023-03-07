using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultadosUI : MonoBehaviour
{
    public Animator anim;

    public void ChangeToPart2()
    {
        anim.SetBool("Part2", true);
    }

    public void ChangeToPart1()
    {
        anim.SetBool("Part2", false);
    }
}
