using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject proyectil;

    public void LanzarProyectil()
    {
        Instantiate(proyectil, this.transform.position, Quaternion.identity);
    }
}
