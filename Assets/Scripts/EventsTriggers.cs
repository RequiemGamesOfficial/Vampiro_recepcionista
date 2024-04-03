using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EventsTriggers : MonoBehaviour
{
    public GameObject player;
    public GameObject gObject;
    public CinemachineVirtualCamera vcam;

    public void TriggerDuelo(GameObject targetObject)
    {
        gObject = targetObject;
        vcam.Follow = gObject.transform;
    }

    public void ResetFollowCameraToPlayer()
    {
        vcam.Follow = player.transform;
    }
}
