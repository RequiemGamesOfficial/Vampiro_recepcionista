using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public Animator anim;
    public RuntimeAnimatorController anim2;

    // Start is called before the first frame update
    void Start()
    {
       
        anim.runtimeAnimatorController = anim2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
