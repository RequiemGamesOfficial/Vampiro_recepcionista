using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoDelCalamar : MonoBehaviour
{

    public AudioSource luzVerde;
    public GameObject dollyMu�eca;
    public GameObject player;

    void Start()
    {
        StartCoroutine(OpenDolli(5.0f, 3.0f));
    }

    IEnumerator OpenDolli(float fireTime, float waitTime)
    {
        while (true)
        {
            dollyMu�eca.SetActive(false);
            luzVerde.Play();
            yield return new WaitWhile(() => luzVerde.isPlaying);
            dollyMu�eca.SetActive(true);
            luzVerde.Stop();
            yield return new WaitForSeconds(waitTime);
        }
    }
}
