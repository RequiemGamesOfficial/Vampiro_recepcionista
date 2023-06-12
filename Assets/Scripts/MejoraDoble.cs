using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraDoble : MonoBehaviour
{
    Manager manager;
    [SerializeField]
    [Range(5, 10)]
    int idObjetoMejora;
    public GameObject buttonCompra, buttonCambio;
    bool comprado;

    public GameObject objetoCambio;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        if(idObjetoMejora == 5 && manager.playa1 >= 1)
        {
            comprado = true;
        }
        if (idObjetoMejora == 6 && manager.playa2 >= 1)
        {
            comprado = true;
        }
        if (idObjetoMejora == 7 && manager.playa3 >= 1)
        {
            comprado = true;
        }
        if (idObjetoMejora == 8 && manager.japones1 >= 1)
        {
            comprado = true;
        }
        if (idObjetoMejora == 9 && manager.japones2 >= 1)
        {
            comprado = true;
        }
        if (idObjetoMejora == 10 && manager.japones3 >= 1)
        {
            comprado = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (comprado)
            {
                buttonCambio.SetActive(true);
            }
            else
            {
                buttonCompra.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonCambio.SetActive(false);
            buttonCompra.SetActive(false);
        }
    }

    public void Cambio()
    {
        objetoCambio.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Comprado(bool comprar)
    {
        comprado = comprar;
    }
}
