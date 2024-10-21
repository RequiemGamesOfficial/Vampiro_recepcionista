using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoCiega : MonoBehaviour
{
    public Animator anim;
    SpriteRenderer spritePlayer;
    public SpriteRenderer[] objectToHide;

    private void Start()
    {
        spritePlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>();
    }

    public void SetOffState()
    {
        int randomNumber = Random.Range(1, 3);

        if (randomNumber == 1)
        {
            anim.Play("Off2");
        }
        else if (randomNumber == 2)
        {
            anim.Play("Off3");
        }
    }


    public void FocoOff2()
    {      
        spritePlayer.sortingLayerName = "HideUI";
    }
    public void FocoOff3()
    {
        // Itera sobre cada SpriteRenderer y desactiva el componente
        foreach (SpriteRenderer sprite in objectToHide)
        {
            sprite.enabled = false;
        }
    }

    //Resetear Todas las animaciones
    public void OffReset()
    {
        spritePlayer.sortingLayerName = "Default";
        // Itera sobre cada SpriteRenderer y desactiva el componente
        foreach (SpriteRenderer sprite in objectToHide)
        {
            sprite.enabled = true;
        }
    }
}
