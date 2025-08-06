using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{

    public GameObject tutorialDiablo, TutorialPerro;
    public LogroManager logroManager;


    public bool tutorial2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (!tutorial2)
            {
                tutorial2 = true;
                Tutorial1();
            }
            else
            {
                Tutorial2();
            }
        }
    }

    public void Tutorial1()
    {
        TutorialPerro.SetActive(true);
        tutorialDiablo.SetActive(false);
    }

    public void Tutorial2()
    {
        logroManager.SetUnlockAchievement("TUTORIAL_COMPLETED");
        TutorialPerro.SetActive(false);
    }
}
