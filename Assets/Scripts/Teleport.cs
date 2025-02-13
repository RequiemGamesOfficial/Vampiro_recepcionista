using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool detected;

    public AudioSource audioSource;
    public GameObject button, player;
    public GameObject pet;

    public Animator animfadeOut;

    private void Start()
    {
        pet = GameObject.FindGameObjectWithTag("Pet");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
        {
            ChangeFloor();
        }
    }

    public void ChangeFloor()
    {
        audioSource.Play();
        player.transform.position = new Vector3(0, 0f, 0);
        if (pet != null)
        {
            pet.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        }
        animfadeOut.Play("FadeIn");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //button Android 
            collision.gameObject.GetComponent<DynamicBotton>().UpdateButton(this.gameObject, 0);

            detected = true;
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //button Android 
            collision.gameObject.GetComponent<DynamicBotton>().ResetButton();

            detected = false;
            button.SetActive(false);
        }
    }
}
