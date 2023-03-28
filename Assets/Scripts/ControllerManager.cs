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
    [SerializeField] private float tiempoPerdidaLiana;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        rgb2D = GetComponent<Rigidbody2D>();
        bC2d = GetComponent<BoxCollider2D>();
    }

    public void OnSkate()
    {
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
        if(skate != null)
        {
            if (skate.skateController)
            {
                skate.skateController = false;
            }
        }
    }

    public void OnLiana(float lianaPosx)
    {
        Debug.Log("on liana");
        playerController.explorador = true;
        transform.position = new Vector3(lianaPosx,transform.position.y,0);
        rgb2D.bodyType = RigidbodyType2D.Kinematic;
        rgb2D.velocity = new Vector2(0f, 0f);
    }
    public void OffLiana()
    {
        Debug.Log("off liana");
        playerController.explorador = false;
        rgb2D.bodyType = RigidbodyType2D.Dynamic;
    }
    public void AttackInLiana()
    {
        OffLiana();
        rgb2D.AddForce(new Vector2(-100, -500));
        anim.Play("PlayerDamage");
        StartCoroutine(DesactivarColisionLiana());
    }

    IEnumerator DesactivarColisionLiana()
    {
        Physics2D.IgnoreLayerCollision(13, 10, true);
        yield return new WaitForSeconds(tiempoPerdidaLiana);
        Physics2D.IgnoreLayerCollision(13, 10, false);
    }
}
