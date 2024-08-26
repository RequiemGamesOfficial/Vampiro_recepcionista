using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivadorCocina : MonoBehaviour
{
    public GameObject obetoExtra;
    public Canvas canvasWorld;
    public AudioSource audioSource;
    public Vector3 newOffsetCamera;
    CinemachineCameraOffset cameraOffset;

    private void Start()
    {
        canvasWorld.worldCamera = Camera.main;
        cameraOffset = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineCameraOffset>();
        cameraOffset.m_Offset = newOffsetCamera;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            if (obetoExtra != null)
            {
                obetoExtra.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraOffset.m_Offset = new Vector3(0, 0, 0);
            if (obetoExtra != null)
            {               
                obetoExtra.SetActive(false);
            }
        }
    }
}
