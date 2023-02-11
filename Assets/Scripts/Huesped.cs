using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huesped : MonoBehaviour
{
    public Recepcion recepcion;
   
    public GameObject huespedObject;
    public HuespedData huespedData;
    Animator anim;
    public Animator animSprite;

    //RayCast
    [SerializeField] float distance;
    RaycastHit2D raycastHit2D;
    public bool stop;
    bool interacting;

    void Start()
    {
        recepcion = GameObject.Find("RecepcionManager").GetComponent<Recepcion>();
        anim = GetComponent<Animator>();
        animSprite.SetBool("walk", true);
    }

    private void Update()
    {
        raycastHit2D = Physics2D.Raycast(new Vector2(transform.position.x + 2, transform.position.y), Vector2.right, distance);
        
        if(raycastHit2D.collider != null)
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

    public void RecibirHuesped()
    {
        recepcion.AtencionAlHuesped(huespedObject, huespedData);
        stop = true;
        animSprite.SetBool("walk", false);
    }

    public void ReceptionYes()
    {
        anim.Play("Yes");
        interacting = true;
        transform.gameObject.tag = "Untagged";
        animSprite.SetBool("walk", true);
    }

    public void ReceptionNo()
    {
        anim.Play("No");
        interacting = true;
        transform.gameObject.tag = "Untagged";
        animSprite.SetBool("walk", true);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

}
