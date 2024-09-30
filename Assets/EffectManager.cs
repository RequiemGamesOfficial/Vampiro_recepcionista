using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public bool drogoEffect;

    public CinemachineCameraOffset cameraOffset;
    ChangeVolumeProfile changeVolumeProfile;

    private Vector3 offsetValue;

    public float speed = 2.0f; // La velocidad de cambio
    private float targetOffsetX = 0.5f;

    float timer;
    public float timeToReset;

    void Start()
    {
        cameraOffset = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineCameraOffset>();
         
        changeVolumeProfile = GameObject.FindGameObjectWithTag("Volume").GetComponent<ChangeVolumeProfile>();
        offsetValue = cameraOffset.m_Offset;
    }

    void Update()
    {
        if (drogoEffect)
        {
            // Interpolamos suavemente entre el valor actual y el valor objetivo
            offsetValue.x = Mathf.Lerp(offsetValue.x, targetOffsetX, Time.deltaTime * speed);
            cameraOffset.m_Offset = offsetValue;

            // Cambia la dirección al alcanzar el valor objetivo
            if (Mathf.Abs(offsetValue.x - targetOffsetX) < 0.01f) // Si está cerca del valor objetivo
            {
                targetOffsetX = targetOffsetX == 0.5f ? -0.5f : 0.5f; // Alterna entre 0.5 y -0.5
            }

            timer += Time.deltaTime;
            if(timer >= timeToReset)
            {
                timer = 0;
                ResetEffects();
            }
        }
    }

    public void DrogoEffect()
    {
        changeVolumeProfile.EffectProfile();
        drogoEffect = true;
        timer = 0;
    }

    public void ResetEffects()
    {
        changeVolumeProfile.ResetNormalProfile();
        drogoEffect = false;
        cameraOffset.m_Offset = new Vector3(0, 0, 0);
    }
}
