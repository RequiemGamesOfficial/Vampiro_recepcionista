using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public Animator anim;
    public Manager manager;

    public RuntimeAnimatorController[] animatorPlayer = new RuntimeAnimatorController[17];

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        SetPlayerSkin();
    }

    public void SetPlayerSkin()
    {      
        if (manager.skin != 0)
        {
            ChangeAnimatorID(manager.skin);
        }
    }

    public void ChangeAnimatorID(int id)
    {
        anim.runtimeAnimatorController = animatorPlayer[id];
    }
}
