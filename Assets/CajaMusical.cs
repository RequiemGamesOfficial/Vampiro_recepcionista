using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMusical : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator ghostAnim, anim;

    public float speed = 3;
    GameObject player;
    public Transform ghost;
    Vector3 gInitialPosition;
    PlayerController playerController;

    public bool active;
    public float timer;
    public float timeToStop,timeToRestart;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        gInitialPosition = ghost.position;
    }

    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            //Ghost Regresa al lugar de origen
            Vector2 direction = (gInitialPosition - ghost.position).normalized;
            ghost.position = Vector2.MoveTowards(ghost.position, gInitialPosition, 15 * Time.deltaTime);

            if (timer >= timeToStop)
            {
                timer = 0;
                active = false;
                StopMusicalBox();
            }
        }
        else
        {
            timer -= Time.deltaTime;

            //Accion de ghost cuando el jugador se mueve
            if (playerController.horizontal != 0)
            {
                Vector2 direction = (player.transform.position - ghost.position).normalized;
                ghost.position = Vector2.MoveTowards(ghost.position, player.transform.position, speed * Time.deltaTime);
            }
            if (timer<= timeToRestart)
            {
                timer = 0;
                active = true;
                PlayMusicalBox();
            }
        }    
    }

    void PlayMusicalBox()
    {
        audioSource.Play();
        ghostAnim.Play("Stop");
    }

    void StopMusicalBox()
    {
        audioSource.Stop();
        ghostAnim.Play("Attack");
    }

}
