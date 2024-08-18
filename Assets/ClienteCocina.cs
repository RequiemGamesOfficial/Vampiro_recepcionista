using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteCocina : MonoBehaviour
{
    Animator anim;
    public Animator animSprite;

    //RayCast
    [SerializeField] float distance;
    RaycastHit2D raycastHit2D;
    public bool stop;
    bool interacting;
    public int[] ingPedidos = new int[4];
    public Sprite[] ingredientesSprites;
    public SpriteRenderer[] ingredienteBurger;
    int random1, random2, random3, random4;
    Vector4 ingredientesRandom;
    RecibidorCocina recibidorCocina;

    void Start()
    {       
        anim = GetComponent<Animator>();
        animSprite.SetBool("walk", true);
        //Asignar ingredientes
        CrearHamburgesa();
    }

    private void Update()
    {
        raycastHit2D = Physics2D.Raycast(new Vector2(transform.position.x + 2, transform.position.y), Vector2.right, distance);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.CompareTag("Huesped"))
            {
                Debug.DrawRay(new Vector2(transform.position.x + 1, transform.position.y), Vector2.right * distance, Color.green);
                stop = true;
                animSprite.SetBool("walk", false);
            }
        }
        if (raycastHit2D.collider == null)
        {
            Debug.Log("walk");
            Debug.DrawRay(new Vector2(transform.position.x + 1, transform.position.y), Vector2.right * distance, Color.red);
            stop = false;
            animSprite.SetBool("walk", true);
        }

        if (!stop && !interacting)
        {
            transform.Translate(5f * Time.deltaTime, 0, 0);
        }
    }

    public void CrearHamburgesa()
    {
        random1 = Random.Range(1, 6);
        random2 = Random.Range(1, 6);
        random3 = Random.Range(1, 6);
        random4 = Random.Range(1, 6);

        ingredienteBurger[0].sprite = ingredientesSprites[random1];
        ingredienteBurger[1].sprite = ingredientesSprites[random2];
        ingredienteBurger[2].sprite = ingredientesSprites[random3];
        ingredienteBurger[3].sprite = ingredientesSprites[random4];

        ingPedidos[0] = random1;
        ingPedidos[1] = random2;
        ingPedidos[2] = random3;
        ingPedidos[3] = random4;
    }

    public void RecibirHuesped(GameObject recibidor)
    {
        stop = true;
        animSprite.SetBool("walk", false);
        recibidorCocina = recibidor.GetComponent<RecibidorCocina>();
        recibidorCocina.Pedido(ingPedidos[0], ingPedidos[1], ingPedidos[2], ingPedidos[3]);
    }

    public void EntregaComida()
    {
        anim.Play("Salida");
        interacting = true;
        transform.gameObject.tag = "Untagged";
        animSprite.SetBool("walk", true);
    }


    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
