using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumoDroggo : MonoBehaviour
{
    public EffectManager effectManager;
    public BackgroundWobble[] background;

    void Start()
    {
        effectManager = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<EffectManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            effectManager.DrogoEffect();
            //BackGroundEffect();
        }
    }

    void BackGroundEffect()
    {
        for (int i = 0; i < background.Length; i++)
        {
            background[i].enabled = true;
        }
    }
}
