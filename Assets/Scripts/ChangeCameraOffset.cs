using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraOffset : MonoBehaviour
{
    CinemachineCameraOffset cameraOffset;
    public int newX, newY;


    void Start()
    {
        cameraOffset = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineCameraOffset>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            cameraOffset.m_Offset = new Vector3(newX, newY, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraOffset.m_Offset = new Vector3(0, 0, 0);
        }
    }
}
