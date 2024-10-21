using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeVolumeProfile : MonoBehaviour
{
    public Volume volume; // El componente Volume que quieres modificar.
    public VolumeProfile normalProfile, newProfile; // El nuevo perfil que quieres aplicar.

    public void EffectProfile()
    {
        volume.profile = newProfile; // Asignamos el nuevo perfil al volumen.
    }

    public void ResetNormalProfile()
    {
        volume.profile = normalProfile;
    }
}
