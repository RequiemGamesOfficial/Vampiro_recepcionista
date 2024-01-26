using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoDelCalamar : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startClip, stopClip;
    public GameObject demon,damageArea;
    public GameObject fireDemon;
    public GameObject player;
    PlayerController playerController;
    public bool attack,attacking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    public void Update()
    {
        if(attack && playerController.horizontal != 0)
        {
            if (!attacking)
            {
                attacking = true;
                Instantiate(damageArea, player.transform.position, Quaternion.identity);
                var newFire = Instantiate(fireDemon, player.transform.position, Quaternion.identity);
                newFire.transform.parent = player.transform;
            }
        }
    }
    public void DiabloStop()
    {
        attack = false;
        audioSource.clip = startClip;
        audioSource.Play();
    }
    public void DiabloPreAttack()
    {
        audioSource.clip = stopClip;
        audioSource.Play();
    }

    public void DiabloAttack()
    {
        audioSource.Stop();
        attack = true;
    }

}
