using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Manager manager;

    Canvas canvas;

    public GameObject[] buttonAndroid;
    bool disable,disableAndroid;

    private void Awake()
    {       
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        canvas = this.GetComponent<Canvas>();
        if (manager.ui)
        {
            ActiveUI();
        }
        else
        {
            DesactiveUI();
        }

        if (manager.android)
        {
            ActiveAndroid();
        }
        else
        {
            DesactiveAndroid();
        }
    }  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangeUIObjects();           
        }
        //ButtonsAndroid
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ChangeAndroidObjects();
        }
    }

    // UI Manager
    public void ActiveUI()
    {
        disable = false;
        manager.ui = true;
        canvas.sortingLayerName = "UI";
    }
    public void DesactiveUI()
    {
        disable = true;
        manager.ui = false;
        canvas.sortingLayerName = "HideUI";
    }
    public void ChangeUIObjects()
    {
        if (!disable)
        {
            DesactiveUI();
        }
        else
        {
            ActiveUI();
        }
    }
    //Android Manager
    public void ActiveAndroid()
    {
        disableAndroid = false;
        manager.android = true;
        for (int i = 0; i < buttonAndroid.Length; i++)
        {
            buttonAndroid[i].SetActive(true);
        }
    }
    public void DesactiveAndroid()
    {
        disableAndroid = true;
        manager.android = false;
        for (int i = 0; i < buttonAndroid.Length; i++)
        {
            buttonAndroid[i].SetActive(false);
        }
    }
    public void ChangeAndroidObjects()
    {
        Debug.Log("Android");

        if (!disableAndroid)
        {
            for (int i = 0; i < buttonAndroid.Length; i++)
            {
                buttonAndroid[i].SetActive(false);
            }
            disableAndroid = true;
            manager.android = false;
        }
        else
        {
            for (int i = 0; i < buttonAndroid.Length; i++)
            {
                buttonAndroid[i].SetActive(true);
            }
            disableAndroid = false;
            manager.android = true;
        }
    }
}
