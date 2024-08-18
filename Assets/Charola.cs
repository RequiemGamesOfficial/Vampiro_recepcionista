using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charola : MonoBehaviour
{
    GameObject playerUp;
    bool active;
    public Transform colliderTransform;
    public GameObject[] ingrediente = new GameObject[4];
    public int[] ingrID = new int[4];

    private void Update()
    {
        if (active)
        {
            transform.position = playerUp.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerUp = collision.gameObject.transform.GetChild(2).gameObject;
            active = true;
            //transform.parent = playerUp.transform;
            //transform.position = playerUp.transform.GetChild(2).transform.position;
        }

        if (collision.gameObject.CompareTag("Pan1"))
        {
            AgregarIngrediente(collision.gameObject, 1);
            //ingrediente.Add("Pan1");
        }

        if (collision.gameObject.CompareTag("Pan2"))
        {
            AgregarIngrediente(collision.gameObject, 5);
            //ingrediente.Add("Pan2");
        }

        if (collision.gameObject.CompareTag("Lechuga"))
        {
            AgregarIngrediente(collision.gameObject, 4);
            //ingrediente.Add("Lechuga");
        }

        if (collision.gameObject.CompareTag("Jitomate"))
        {
            AgregarIngrediente(collision.gameObject, 3);
            //ingrediente.Add("Jitomate");
        }
        if (collision.gameObject.CompareTag("Carne"))
        {
            //ingrediente.Add("Carne");
            AgregarIngrediente(collision.gameObject, 2);
        }
    }

    void AgregarIngrediente(GameObject ingreGameObj,int id)
    {        
        if (ingrID[3] == 0)
        {
            ingrID[3] = id;
            ingrediente[3] = ingreGameObj;
            ingreGameObj.transform.parent = colliderTransform;
            ingreGameObj.SendMessage("KinematicBody", transform);
        }
        else
        {
            if (ingrID[2] == 0)
            {
                ingrID[2] = id;
                ingrediente[2] = ingreGameObj;
                ingreGameObj.transform.parent = colliderTransform;
                ingreGameObj.SendMessage("KinematicBody", transform);
            }
            else
            {
                if (ingrID[1] == 0)
                {
                    ingrID[1] = id;
                    ingrediente[1] = ingreGameObj;
                    ingreGameObj.transform.parent = colliderTransform;
                    ingreGameObj.SendMessage("KinematicBody", transform);
                }
                else
                {
                    if (ingrID[0] == 0)
                    {
                        ingrID[0] = id;
                        ingrediente[0] = ingreGameObj;
                        ingreGameObj.transform.parent = colliderTransform;
                        ingreGameObj.SendMessage("KinematicBody", transform);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Pan1"))
        {
            collision.gameObject.transform.parent = null;
            collision.SendMessage("DynamicBody");
        }

        if (collision.gameObject.CompareTag("Pan2"))
        {
            collision.gameObject.transform.parent = null;
            collision.SendMessage("DynamicBody");
        }

        if (collision.gameObject.CompareTag("Lechuga"))
        {
            collision.gameObject.transform.parent = null;
            collision.SendMessage("DynamicBody");
        }

        if (collision.gameObject.CompareTag("Jitomate"))
        {
            collision.gameObject.transform.parent = null;
            collision.SendMessage("DynamicBody");
        }
        if (collision.gameObject.CompareTag("Carne"))
        {
            collision.gameObject.transform.parent = null;
            collision.SendMessage("DynamicBody");
        }
    }

    public void LimpiarCharola()
    {
        for (int i = 0; i < ingrediente.Length; i++)
        {
            Destroy(ingrediente[i]);
        }

        for (int i = 0; i < ingrID.Length; i++)
        {
            ingrID[i] = 0;
        }

        ingrediente = new GameObject[4];
    }
}
