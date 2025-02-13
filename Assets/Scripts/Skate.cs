using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skate : MonoBehaviour
{
    GameObject player;
    public SkateAudio skateAudio;
    ControllerManager controllerManager;
    public Transform posPlayer;
    [HideInInspector]
    public bool skateController,grid;
    public bool playerSkating;
    //Movimeinto
    public bool eventBool;
    bool isRight, isLeft, isJump;
    public float horizontal;
    public float speed;
    Rigidbody2D rb;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public float jumpForce;
    bool used,entrada;
    //public bool android;
    public bool useButtonsTouchs;

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
                    if (!eventBool)
                    {
                        isJump = true;
                    }
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
                //Sonido Salto
                skateAudio.JumpSound();
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.5f, groundLayer);
    }
    //Android Buttons
    public void ClickRight()
    {
        isRight = true;
        useButtonsTouchs = true;
        //Playy sonido loop
    }
    public void ReleaseRight()
    {
        isRight = false;
        useButtonsTouchs = false;
        //Stop Sonido loop
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
        if (collision.gameObject.CompareTag("Player") && !used && !entrada)
        {
            entrada = true;
            playerSkating = true;
            player = collision.gameObject;
            controllerManager = player.GetComponent<ControllerManager>();
            controllerManager.skate = this;
            controllerManager.OnSkate();
            player.transform.position = posPlayer.position;
            player.transform.parent = gameObject.transform;
            skateController = true;
            //Empeiza sonido loop
            Debug.Log("Player empeiza a patinar");
            skateAudio.PlayRollingLoopSound();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            skateController = false;
            if (playerSkating)
            {
                player.SendMessage("OffSkate", true);
            }
            used = true;
            //Stop sonido parado
            skateAudio.StopRollingLoopSound();
        }
        if (collision.gameObject.CompareTag("Grind"))
        {
            grid = true;
            //Play sonido Grind
            Debug.Log("GRIDDD");
            skateAudio.GrindSound();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grind"))
        {         
            grid = false;          
        }

        if (collision.gameObject.CompareTag("Player"))
        {           
            if (eventBool)
            {
                Debug.Log("Player exit Skate");
                used = true;
                playerSkating = false;
                skateController = false;
                //Stop sonido Grind
                skateAudio.StopRollingLoopSound();
            }
        }
    }
}
