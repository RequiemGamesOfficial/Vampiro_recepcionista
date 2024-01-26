using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public SpriteRenderer[] spriteElements;
    float alphaValue = 1f;

    public float disappearRate = 1f;
    bool playerEntered = false;

    public GameObject tutorialCanvas;

    private void Update()
    {
        if (playerEntered)
        {
            alphaValue += Time.deltaTime * disappearRate;

            if (alphaValue >= 1)
                alphaValue = 1;

            foreach (SpriteRenderer spriteItem in spriteElements)
            {
                spriteItem.color = new Color(spriteItem.color.r, spriteItem.color.g, spriteItem.color.b, alphaValue);
            }
        }
        else
        {
            alphaValue -= Time.deltaTime * disappearRate;

            if (alphaValue <= 0)
                alphaValue = 0;

            foreach (SpriteRenderer spriteItem in spriteElements)
            {
                spriteItem.color = new Color(spriteItem.color.r, spriteItem.color.g, spriteItem.color.b, alphaValue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerEntered = true;
            tutorialCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            tutorialCanvas.SetActive(false);
        }
    }
}
