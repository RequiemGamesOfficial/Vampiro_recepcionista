using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rgb2D;
    BoxCollider2D bC2d;
    public Animator anim;
    public Skate skate;
    public VidasHabitacion vidasHabitacion;
    [HideInInspector]
    public bool skating;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        rgb2D = GetComponent<Rigidbody2D>();
        bC2d = GetComponent<BoxCollider2D>();
    }

    public void OnSkate()
    {
        Debug.Log("OnSkate");
        skating = true;
        playerController.enabled = false;
        rgb2D.bodyType = RigidbodyType2D.Kinematic;        
        anim.SetBool("Skate", true);
        anim.Play("PlayerSkating");
        vidasHabitacion.skating = true;
        bC2d.isTrigger = true;
    }

    public void OffSkate(bool rebote)
    {
        Debug.Log("OffSkate");
        skating = false;
        transform.parent = null;
        anim.SetBool("Skate", false);
        playerController.enabled = true;
        rgb2D.bodyType = RigidbodyType2D.Dynamic;
        if (rebote)
        {
            rgb2D.AddForce(new Vector2(500, 500));
        }       
        vidasHabitacion.skating = false;
        bC2d.isTrigger = false;
        //Asegurar SkateOff
        if (skate.skateController)
        {
            skate.skateController = false;
        }
    }
}
