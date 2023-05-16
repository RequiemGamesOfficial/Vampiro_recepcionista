using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool detected;

    public AudioSource audioSource;
    public GameObject button, player;

    public Animator animfadeOut;

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
        animfadeOut.Play("FadeIn");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
            button.SetActive(false);
        }
    }
}
