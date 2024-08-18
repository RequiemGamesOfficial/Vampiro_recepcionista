using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    Manager manager;
    public VidasBoss vidasBoss;
    GameObject player, cameraObject;
    public Rigidbody2D rb;
    public Animator animfadeOut;
    public Vector3 currentCheckpoint;
    public GameObject vidaDemon01, vidaDemon02, vidaDemon03;
    public GameObject demon01, demon02, demon03;
    public GameObject demonHit,demonHit1,demonHit2;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.SearchIconSave();
        player = GameObject.FindGameObjectWithTag("Player");
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void SetCheckpoint(Vector3 coordenadas)
    {
        currentCheckpoint = coordenadas;
    }
    public void PlayerDead()
    {
        Debug.Log("PlayerDead-DemonBoss");
        rb.velocity = new Vector2(0, 0);
        player.transform.position = currentCheckpoint;
        cameraObject.transform.position = currentCheckpoint;
        animfadeOut.Play("FadeIn");
        vidasBoss.dead = false;
    }
    public void FadeToBlack()
    {
        Debug.Log("FadeToBlack-DemonBoss");
        animfadeOut.Play("FadeIn");
    }
    public void ButtonBoss1()
    {
        demonHit.SetActive(true);
        vidaDemon01.SetActive(false);
        demon01.SetActive(false);
    }
    public void ButtonBoss2()
    {
        demonHit1.SetActive(true);
        vidaDemon02.SetActive(false);
        demon02.SetActive(false);
    }
    public void ButtonBoss3()
    {
        demonHit2.SetActive(true);
        vidaDemon03.SetActive(false);
        demon03.SetActive(false);
    }
}
