using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDelatador : MonoBehaviour
{
    public GameObject alertaIcon;
    public CambioDeLugar cambioDeLugar;
    bool detected;
    float timer;
    public Hotel hotel;
    public AudioSource audioSource;

    private void Update()
    {
        if (detected)
        {
            timer += Time.deltaTime;
            if (timer >=0.5f)
            {
                alertaIcon.SetActive(false);
                cambioDeLugar.ChangeFloor();
                detected = false;
                hotel.FadeToBlack();
                timer = 0;               
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Detectado();
        }
    }

    public void Detectado()
    {
        alertaIcon.SetActive(true);
        detected = true;       
        audioSource.Play();
    }
}
