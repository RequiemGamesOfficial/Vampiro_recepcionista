using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAndroid : MonoBehaviour
{

    public Image right, left;
    public Sprite rightIcon, leftIcon, upIcon, downIcon;

    public void NormalButtons()
    {
        right.sprite = rightIcon;
        left.sprite = leftIcon;
    }
    public void LaderButtons()
    {
        right.sprite = upIcon;
        left.sprite = downIcon;
    }
}
