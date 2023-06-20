using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTransform;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public float distance;
    public float speed;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {

        distance = Mathf.Abs(this.transform.position.x - playerTransform.position.x);

        if (distance > 3)
        {
            anim.SetBool("move", true);
            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);
            //Vista de personaje
            if (transform.position.x < playerTransform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            //Vista de personaje          
        }
        else
        {
            anim.SetBool("move", false);
        }               
    }
}
