using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecibidorCocina : MonoBehaviour
{
    Manager manager;
    public Stats stats;

    public bool atendiendo;
    public Charola charola;
    public GameObject cliente;
    public GenerateGuestKitchen generateGuestKitchen;
    public GenerateBurger generateBurger;
    public int[] ingrPedidos;
    bool detected;

    // Buttonmanager
    public ButtonCocinaFunction buttonCocinaFunction;
    bool iniciar;

    public GameObject particleStars;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            if (!atendiendo)
            {
                iniciar = true;
                buttonCocinaFunction.ButtonIniciar();
            }
            else
            {
                buttonCocinaFunction.ButtonCocina();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            if (!atendiendo)
            {
                buttonCocinaFunction.ActivarBIniciar();
            }
            else
            {
                buttonCocinaFunction.ActivarBCocina();
            }
        }
        
        if (collision.gameObject.CompareTag("Huesped"))
        {
            buttonCocinaFunction.waiting = false;
            cliente = collision.gameObject;
            cliente.SendMessage("RecibirHuesped", this.gameObject);
            atendiendo = true;
            Debug.Log("Atendiendo True");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            buttonCocinaFunction.DesactivarButtons();
        }
    }

    //Mensaje enviado desde ClienteCocina 
    public void Pedido(int id,int id1,int id2,int id3)
    {
        ingrPedidos[0] = id;
        ingrPedidos[1] = id1;
        ingrPedidos[2] = id2;
        ingrPedidos[3] = id3;
    }

    public void EntregaComidaManager()
    {
        atendiendo = false;
        Debug.Log("Atendiendo False");
        if (cliente != null)
        {
            cliente.SendMessage("EntregaComida");
            ChecarCoicidencia();
            buttonCocinaFunction.ActivarBIniciar();
            generateBurger.ActiveGenerate(false);
            //generateGuestKitchen.CheckGuestHunger();
        }
        else
        {
            buttonCocinaFunction.ActivarBIniciar();
            generateBurger.ActiveGenerate(false);
            //generateGuestKitchen.CheckGuestHunger();
        }
    }

    public void ChecarCoicidencia()
    {
        if(charola.ingrID[0] == ingrPedidos[0])
        {
            Debug.Log("+ 5 puntos de Reputacion");
            Instantiate(particleStars, new Vector3(this.transform.position.x - 0.5f, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            manager.reputation += 5;
        }
        else
        {
            Debug.Log("Los ingredientes no coiciden"+ charola.ingrID[0]+"/=" + ingrPedidos[0]);
        }

        if (charola.ingrID[1] == ingrPedidos[1])
        {
            Debug.Log("+ 5 puntos de Reputacion");
            Instantiate(particleStars, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            manager.reputation += 5;
        }
        else
        {
            Debug.Log("Los ingredientes no coiciden" + charola.ingrID[0] + "/=" + ingrPedidos[0]);
        }

        if (charola.ingrID[2] == ingrPedidos[2])
        {
            Debug.Log("+ 5 puntos de Reputacion");
            Instantiate(particleStars, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + .5f, this.transform.position.z), Quaternion.identity);
            manager.reputation += 5;
        }
        else
        {
            Debug.Log("Los ingredientes no coiciden" + charola.ingrID[0] + "/=" + ingrPedidos[0]);
        }

        if (charola.ingrID[3] == ingrPedidos[3])
        {
            Debug.Log("+ 5 puntos de Reputacion");
            Instantiate(particleStars, new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            manager.reputation += 5;
        }
        else
        {
            Debug.Log("Los ingredientes no coiciden" + charola.ingrID[0] + "/=" + ingrPedidos[0]);
        }
        stats.SetReputation();
        ingrPedidos = new int[4];
        charola.LimpiarCharola();

    }
}
