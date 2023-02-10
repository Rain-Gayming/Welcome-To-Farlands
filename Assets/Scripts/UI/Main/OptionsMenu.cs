using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [Header("Fullscreen")]
    public TMP_Dropdown fullscreenDropdown;

    [Header("Shadows")]
    public TMP_Dropdown shadowDropdown;

    [Header("Textures")]
    public TMP_Dropdown texturesDropdown;

    [Header("Volume")]
    public AudioMixer audioMixer;
    public Slider masterVolSlider;
    public Slider musicVolSlider;
    public Slider voicesVolSlider;
    public TMP_Text masterVolText;
    public TMP_Text musicVolText;
    public TMP_Text voicesVolText;

    [Header("Sensitivity")]
    public Slider xSensitivitySlider;
    public Slider ySensitivitySlider;
    public TMP_Text xSensitivityText;
    public TMP_Text ySensitivityText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (fullscreenDropdown.value)
        {
            case 0: 
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            break;  

            case 1:             
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            break; 

            case 2: 
                Screen.fullScreenMode = FullScreenMode.Windowed;
            break;           
        }    
    
        switch(shadowDropdown.value){

            case 0:
                QualitySettings.shadowResolution = ShadowResolution.Low;
            break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.Medium;

            break;
            case 2:
                QualitySettings.shadowResolution = ShadowResolution.High;
            break;
            case 3:
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
            break;
        }
        
        switch(texturesDropdown.value){

            case 0:
                QualitySettings.masterTextureLimit = 0;
            break;
            case 1:
                QualitySettings.masterTextureLimit = 1;
            break;
            case 2:
                QualitySettings.masterTextureLimit = 2;
            break;
            case 3:
                QualitySettings.masterTextureLimit = 3;
            break;
        }
        
        #region audio
        audioMixer.SetFloat("MasterVol", masterVolSlider.value);
        audioMixer.SetFloat("MusicVol", musicVolSlider.value);
        audioMixer.SetFloat("VoicesVol", voicesVolSlider.value);

        masterVolText.text = "Master Volume (" + (masterVolSlider.value + 80) + "): ";
        musicVolText.text = "Music Volume (" + (musicVolSlider.value + 80) + "): ";
        voicesVolText.text = "Voices Volume (" + (voicesVolSlider.value + 80) + "): ";
        #endregion
    
        if(PlayerManager.instance){
            PlayerManager.instance.xSensitivity = xSensitivitySlider.value * 1.5f;
            PlayerManager.instance.ySensitivity = ySensitivitySlider.value * 1.5f;
        }

        xSensitivityText.text = "X Sensitivity (" + xSensitivitySlider.value + "):";
        ySensitivityText.text = "Y Sensitivity (" + ySensitivitySlider.value + "):";
    
    }
}
