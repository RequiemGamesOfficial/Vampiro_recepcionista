using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    Manager manager;
    ChangeLook changeLook;
    public GameObject skinSelect;
    public GameObject[] skinButton = new GameObject[16];
    public SoundAnimator soundAnimator;
    public int portalNumber;
    public int numberToPortal;
    public GameObject portal,miniportal;
    public GameObject tutorial;
    public Slider portalSlider;
    public GameObject sliderObject;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        changeLook = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangeLook>();
        for (int i = 0; i < manager.globalDead.Length; i++)
        {
            if (manager.globalDead[i] >= 5)
            {
                skinButton[i].SetActive(true);
                portalNumber += 1;
            }
            if (manager.huespedDead[i] >= 1)
            {
                portalNumber += 1;
            }
        }
        Debug.Log("Huesped Number" + portalNumber);
        if(portal != null)
        {
            portalSlider.value = portalNumber;
            if (portalNumber >= 2)
            {
                miniportal.SetActive(true);
                sliderObject.SetActive(true);
            }
            if (portalNumber >= numberToPortal)
            {
                portal.SetActive(true);
                tutorial.SetActive(false);
                miniportal.SetActive(false);
                sliderObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinSelect.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinSelect.SetActive(false);
        }
    }

    public void SelectSkinID(int id)
    {
        //Play audio
        soundAnimator.PlayAudioClip02();
        manager.skin = id;
        changeLook.ChangeAnimatorID(id);
    }
}
