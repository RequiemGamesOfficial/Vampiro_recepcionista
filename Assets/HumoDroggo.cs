using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumoDroggo : MonoBehaviour
{
    public EffectManager effectManager;

    void Start()
    {
        effectManager = GameObject.FindGameObjectWithTag("HotelManager").GetComponent<EffectManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            effectManager.DrogoEffect();
        }
    }


}
