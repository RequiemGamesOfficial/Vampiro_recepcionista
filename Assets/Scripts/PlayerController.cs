using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    public Animator anim;

    public Rigidbody2D rb;
    public float speed;
    public float iceSpeed;
    float impulsoSpeed = 0.003f;
    float impulsoMax = 2;
    float impulsoMin = -2;
    public float jumpForce;

    bool isFacingRight = true;
    public SpriteRenderer spriteRenderer;

    public GameObject groundCheck, up, down;
    public LayerMask groundLayer;

    public Vector2 velocidadRebote;
    public bool canMove;

    float currentGravity;
    bool normalGravity = true;

    //habitaciones
    public bool esquimal, marciano;

    //Android Buttons
    bool isLeft = false;
    bool isRight = false;
    bool isJump = false;
    public bool android;

    private void Start()
    {
        currentGravity = rb.gravityScale;
    }

    void Update()
    {
        if (canMove && !android)
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                isRight = true;
            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                isLeft = true;
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
        //Android
        if (canMove)
        {
            if (isJump && marciano)
            {
                Debug.Log("Cambio");
                //GravedadAlReves();
            }

            if (isLeft)
            {
                horizontal = -1;
                iceSpeed = -1;
                anim.SetFloat("horizontal", horizontal);
            }
            if (isRight)
            {
                horizontal = 1;
                iceSpeed = 1;
                anim.SetFloat("horizontal", horizontal);
            }
            if (!isLeft && !isRight)
            {
                horizontal = 0;
                anim.SetFloat("horizontal", horizontal);
            }
            if (isJump && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.Play("PlayerJump");
                isJump = false;
                if (marciano)
                {
                    GravedadAlReves();
                }             
            }
        }
        Flip();

        //Esquimal
        if (esquimal)
        {
            if (isRight)
            {
                iceSpeed += impulsoSpeed;
                if(iceSpeed > impulsoMax)
                {
                    iceSpeed = impulsoMax;
                }
            }
            if (isLeft)
            {
                iceSpeed -= impulsoSpeed;
                if (iceSpeed < impulsoMin)
                {
                    iceSpeed = impulsoMin;
                }
            }

            if (iceSpeed > 0)
            {
                iceSpeed -= impulsoSpeed;
                if (iceSpeed < 0)
                {
                    iceSpeed = 0;
                }
            }
            if (iceSpeed < 0)
            {
                iceSpeed += impulsoSpeed;
                if (iceSpeed > 0)
                {
                    iceSpeed = 0;
                }
            }
        }        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (esquimal)
        {
            rb.AddForce(transform.right * iceSpeed, ForceMode2D.Impulse);
        }       
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer);
    }

    public void GravedadAlReves()
    {
        rb.gravityScale *= -1;
        jumpForce *= -1;
        if (normalGravity)
        {
            Debug.Log("alreves");
            spriteRenderer.flipY = true;
            groundCheck.transform.position = up.transform.position;
            normalGravity = false;
        }
        else
        {
            Debug.Log("Noalreves");
            spriteRenderer.flipY = false;
            groundCheck.transform.position = down.transform.position;
            normalGravity = true;
        }

    }
    public void RestablecerGravedadAlReves()
    {
        if (!normalGravity)
        {
            GravedadAlReves();
        }
    }

    public void CambioDeGravedad(float gravedad)
    {
        rb.gravityScale = gravedad;
        jumpForce = 3;
    }
    public void RestablecerGravedad()
    {
        rb.gravityScale = currentGravity;
        jumpForce = 6;
    }

    public void Rebote(Vector2 puntoGolpe)
    {       
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }

    //Android Buttons
    public void ClickLeft()
    {
        isLeft = true;
    }
    public void ReleaseLeft()
    {
        isLeft = false;
    }
    public void ClickRight()
    {
        isRight = true;
    }
    public void ReleaseRight()
    {
        isRight = false;
    }
    public void ClickJump()
    {
        isJump = true;
    }

}
