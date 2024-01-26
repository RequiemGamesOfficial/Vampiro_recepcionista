using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHotel : MonoBehaviour
{
    //PlayerController playerController;
    public Hotel hotel;
    public PlayerController playerController;

    public float timer;
    public float limitTime;
    bool timeOut;

    public Slider slider;

    public GameObject resultadosPanel;
    public GameObject fade;

    void Start()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        slider.maxValue = limitTime;
        SetValue(limitTime);
        timer = limitTime;
    }

    void Update()
    {
        if(timer >= 0 && !timeOut)
        {
            timer -= Time.deltaTime;
            SetValue(timer);
            if(timer <= 0)
            {
                TimeOver();
            }
        }     
    }

    public void SetValue(float time)
    {
        slider.value = time;
    }

    public void TimeOver()
    {
        print("TimeOver");
        hotel.ChecarHaibitaciones();
        fade.SetActive(false);
        //Time.timeScale = 0;
        resultadosPanel.SetActive(true);
        playerController.FalseMove();
        timeOut = true;
    }
}
