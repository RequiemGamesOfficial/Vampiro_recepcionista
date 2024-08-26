using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 mouseRawPosition;
    Vector3 mousePosition;
    public Camera cameraPaint;

    float maxBrushSize = 4;
    float minBrushSize = 1;

    public float currentBrushSize = 1;

    void Update()
    {
        mouseRawPosition = cameraPaint.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mouseRawPosition.x, mouseRawPosition.y, 0);
        transform.position = mousePosition;
    }

    void ChangeBrushSize()
    {
        transform.localScale = new Vector3(currentBrushSize, currentBrushSize, 1);
    }

}
