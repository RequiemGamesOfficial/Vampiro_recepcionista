using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSkin : MonoBehaviour
{
    public bool detected;
    public Animator anim;
    public SkinManager skinManager;
    public SkinSelect skinSelect;
    public SoundAnimator soundAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detected)
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
        //Play audio
        soundAnimator.PlayAudioClip02();
        skinManager.SelectSkinID(skinSelect.skin);
    }
}
