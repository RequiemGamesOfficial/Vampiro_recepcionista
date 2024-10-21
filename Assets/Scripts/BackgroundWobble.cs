using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWobble : MonoBehaviour
{
    public float frequency = 2f; // Frecuencia del movimiento
    public float amplitude = 0.1f; // Amplitud del movimiento

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = originalPosition + new Vector3(0, offsetY, 0);
    }
}
