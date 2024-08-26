using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockAccident : MonoBehaviour
{
    public AccidentPanel accidentPanel;
    
    public int cost;
    public int accidentId;
    public int reputation;
    public TMP_Text costText;

    void Start()
    {
        costText.text = ("$" + cost);
    }

    public void SetAccidentID(int id)
    {
        accidentId = id;
    }

    public void PayAccidentBlock()
    {
        accidentPanel.PayAccident(accidentId,cost,reputation);
        gameObject.SetActive(false);
    }
}
