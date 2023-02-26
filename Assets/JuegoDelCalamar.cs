using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoDelCalamar : MonoBehaviour
{

    public AudioSource luzVerde;
    public GameObject dollyMuñeca;
    public GameObject player;

    void Start()
    {
        StartCoroutine(OpenDolli(5.0f, 3.0f));
    }

    IEnumerator OpenDolli(float fireTime, float waitTime)
    {
        while (true)
        {
            dollyMuñeca.SetActive(false);
            luzVerde.Play();
            yield return new WaitWhile(() => luzVerde.isPlaying);
            dollyMuñeca.SetActive(true);
            luzVerde.Stop();
            yield return new WaitForSeconds(waitTime);
        }
    }
}
