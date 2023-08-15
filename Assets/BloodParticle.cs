using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    [SerializeField]
    float speed;
    public string target;
    GameObject targetBlood;

    void Start()
    {
        targetBlood = GameObject.FindWithTag(target);
        GetComponent<Rigidbody2D>().AddRelativeForce(Random.onUnitSphere * speed);
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetBlood.transform.position, 10 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target))
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
}
