using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skate : MonoBehaviour
{
    GameObject player;
    ControllerManager controllerManager;
    public Transform posPlayer;
    [HideInInspector]
    public bool skateController;
    //Movimeinto
    bool isRight, isLeft, isJump;
    public float horizontal;
    public float speed;
    Rigidbody2D rb;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public float jumpForce;
    bool used;
    //public bool android;
    bool useButtonsTouchs;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }
    private void Update()
    {
        if (skateController)
        {
            if (!useButtonsTouchs)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    isRight = true;
                    isLeft = false;
                }
                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    isLeft = true;
                    isRight = false;
                }
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    isRight = false;
                    isLeft = false;
                }
                if (Input.GetKeyDown("space"))
                {
                    isJump = true;
                }
            }

            //movimiento
            if (isRight)
            {
                horizontal = 1;
            }
            if (isLeft)
            {
                horizontal = -1;
            }
            if (!isRight && !isLeft)
            {
                horizontal = 0;
            }

            rb.velocity = new Vector2((horizontal + 0.5f) * speed, rb.velocity.y);

            if (isJump && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJump = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.5f, groundLayer);
    }
    //Android Buttons
    public void ClickRight()
    {
        isRight = true;
        useButtonsTouchs = true;
    }
    public void ReleaseRight()
    {
        isRight = false;
        useButtonsTouchs = false;
    }

    public void ClickLeft()
    {
        isLeft = true;
        useButtonsTouchs = true;
    }
    public void ReleaseLeft()
    {
        isLeft = false;
        useButtonsTouchs = false;
    }
    public void ClickJump()
    {
        isJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !used)
        {
            player = collision.gameObject;
            controllerManager = player.GetComponent<ControllerManager>();
            controllerManager.skate = this;
            controllerManager.OnSkate();
            player.transform.position = posPlayer.position;
            player.transform.parent = gameObject.transform;
            skateController = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            skateController = false;
            player.SendMessage("OffSkate", true);
            used = true;
        }
    }


}
