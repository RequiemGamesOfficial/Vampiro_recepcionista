using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorPalyer : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerController playerController;
    public string cinematicaMuerte;

    public void PlayerDead()
    {
        rb.bodyType = RigidbodyType2D.Static;
        playerController.canMove = false;
    }

    public void MoveTrue()
    {
        playerController.canMove = true;
    }

    public void CinematicaMuerte()
    {
        SceneManager.LoadScene(cinematicaMuerte, LoadSceneMode.Single);
    }
}
