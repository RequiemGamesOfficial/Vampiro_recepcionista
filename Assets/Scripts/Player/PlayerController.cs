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
    public float boucing;

    bool isFacingRight = true;
    public SpriteRenderer spriteRenderer;

    public float coyoteTime = 0.2f;
    float coyoteTimeCounter;

    public GameObject groundCheck, up, down;
    public LayerMask groundLayer;
    public float groundRadius = 0.1f;

    public Vector2 velocidadRebote;
    public bool canMove, waterState;
    public GameObject waterParticle;

    float currentGravity;
    bool normalGravity = true;

    //habitaciones
    public bool esquimal, marciano,explorador;

    //Android Buttons
    public bool isLeft = false;
    bool isRight = false;
    bool isJump = false;
    //public bool android;
    bool useButtonsTouchs;

    public bool footConcrete,footGrass;

    //Modificar vista de camara
    //public CinemachineCameraOffset

    private void Start()
    {
        currentGravity = rb.gravityScale;
    }

    void Update()
    {
        //Coyote time
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        //PC buttons
        if (canMove && !useButtonsTouchs)
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
            if (Input.GetKeyDown("space") && !anim.GetBool("isInteracting"))
            {
                isJump = true;
            }
            if (Input.GetKeyUp("space"))
            {
                coyoteTimeCounter = 0f;
            }
        }       
        //Android
        if (canMove && !anim.GetBool("isInteracting"))
        {
            anim.SetBool("ground",IsGrounded());
            Flip();
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
            //Jump
            if (!explorador)
            {
                if (isJump && coyoteTimeCounter > 0f || isJump && waterState)
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
            else
            {
                if (isJump)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    if (isFacingRight)
                    {
                        Debug.Log("JumpRight!");
                        rb.AddForce(new Vector2(500, 500));
                    }
                    else
                    {
                        Debug.Log("JumpLeft!");
                        rb.AddForce(new Vector2(-500, 800));
                    }
                    isJump = false;
                }
            }           
        }        
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
        //Movimiento aplicado
        if (!explorador)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (esquimal)
            {
                rb.AddForce(transform.right * iceSpeed, ForceMode2D.Impulse);
            }
        }
        else
        {
            if(Input.GetAxisRaw("Vertical") != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * speed);
                anim.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, horizontal * speed);
                anim.SetFloat("vertical", 0);
            }                    
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
        return Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, groundLayer);
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

    public void CambioDeGravedad(float gravedad,bool water)
    {
        Debug.Log("Cambio de gravedad" + gravedad + water);
        rb.gravityScale = gravedad;
        jumpForce = 3;
        if (water)
        {
            anim.SetBool("Water", true);
            waterState = water;
            Instantiate(waterParticle, down.transform.position, Quaternion.identity);
        }
    }
    public void RestablecerGravedad(bool water)
    {
        rb.gravityScale = currentGravity;
        jumpForce = 6;        
        if (water)
        {
            anim.SetBool("Water", false);
            waterState = false;
            Instantiate(waterParticle, down.transform.position, Quaternion.identity);
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {       
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }

    //Permitir y Negar movimiento del juagdor
    public void TrueMove()
    {
        canMove = true;
    }
    public void FalseMove()
    {
        canMove = false;
        horizontal = 0;
        anim.SetFloat("horizontal", 0);
    }
    public void TrueMoveSamurai()
    {
        canMove = true;
    }
    public void FalseMoveSamurai()
    {
        canMove = false;
        horizontal = 0;
        anim.SetFloat("horizontal", 0);
        anim.Play("P_Guard");
    }
    public void Attack()
    {
        anim.Play("P_Attack");
    }

    //Android Buttons
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
    public void ClickJump()
    {
        if (!anim.GetBool("isInteracting"))
        {
            isJump = true;
        }
    }
    public void ReleaseJump()
    {
        coyoteTimeCounter = 0f;
    }

    //Movimiento falso y verdadero

    public void PlayerPet()
    {
        CantNotMove();
        anim.Play("Pet");
    }
    public void CantNotMove()
    {
        canMove = false;
        rb.velocity = new Vector2(0, 0);
        horizontal = 0;
    }

    public void CanMove()
    {
        canMove = true;
    }

    public void NotMove()
    {
        rb.velocity = new Vector2(0, 0);
        horizontal = 0;
    }
    public void Bouncing()
    {
        Debug.Log("ReboteArriba");
        rb.velocity = new Vector2(rb.velocity.x, boucing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Concrete"))
        {
            footConcrete = true;
        }
        if (collision.gameObject.CompareTag("Grass"))
        {
            footGrass = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Concrete"))
        {
            footConcrete = false;
        }
        if (collision.gameObject.CompareTag("Grass"))
        {
            footGrass = false;
        }
    }

}
