using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider fxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private int fullScreen;
    [SerializeField] private Toggle fullScreenToggle;

    void Start()
    {
        LoadSettings();
    }
    public void LoadSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        fxSlider.value = PlayerPrefs.GetFloat("FXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionScreen");
        fullScreen = PlayerPrefs.GetInt("FullScreen");
        if(fullScreen == 1)
        {
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }
    }
    public void SetVolumeMasterPref()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }
    public void SetVolumeFXPref()
    {
        PlayerPrefs.SetFloat("FXVolume", fxSlider.value);
    }
    public void SetVolumeMusicPref()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    public void SetResolutionPref()
    {
        PlayerPrefs.SetInt("ResolutionScreen", resolutionDropdown.value);
    }
    public void SetFullScreen(bool fScreen)
    {
        if (fScreen)
        {
            fullScreen = 1;
            PlayerPrefs.SetInt("FullScreen", fullScreen);
        }
        else
        {
            fullScreen = 0;
            PlayerPrefs.SetInt("FullScreen", fullScreen);
        }
    }
}
