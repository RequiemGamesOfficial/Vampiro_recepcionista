using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLeftRight : MonoBehaviour
{
    public bool detected;
    public Animator anim;
    public bool right;
    public SoundAnimator soundAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2) && detected)
        {
            ButtonPress();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detected = false;
        }
    }

    void ButtonPress()
    {
        soundAnimator.PlayAudioClip01();
        if (right)
        {
            anim.SetTrigger("right");
        }
        else
        {
            anim.SetTrigger("left");
        }       
    }
}
