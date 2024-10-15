using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaHombre : MonoBehaviour
{
    public GameObject[] objectsToOpen;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (AllObjectsDestroyed())
            {
                anim.SetBool("open", true);
                Debug.Log("¡Todos los objetos han sido destruidos!");
                enabled = false;  // Desactiva este script si ya no es necesario
            }
        }
    }

    // Método para verificar si todos los objetos del array fueron destruidos
    private bool AllObjectsDestroyed()
    {
        foreach (GameObject obj in objectsToOpen)
        {
            if (obj != null)  // Si hay al menos un objeto que no es null, devuelve false
                return false;
        }
        return true;  // Todos los objetos son null
    }
}
