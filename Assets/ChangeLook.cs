using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public Animator anim;
    Manager manager;

    public RuntimeAnimatorController[] animatorPlayer = new RuntimeAnimatorController[17];

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
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
