using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider ambientSlider;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    public AudioMixerGroup AmbientAudioMixer;
    public AudioMixerGroup EffectsAudioMixer;

    Resolution[] resolutions;

    void Start()
    {
        //Get the stored settings from a previous session and adjust the menu accordingly
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume"); //Defaults to 0 if no data is found
        ambientSlider.value = PlayerPrefs.GetFloat("AmbientVolume"); //Defaults to 0 if no data is found

        qualityDropdown.value = QualitySettings.GetQualityLevel(); //Get the quality the user had already set on the launcher

        FillResolutionDropdown(); //Fill the resolutiondropdown with all available resolutions, also sets the default value on current resolution
    }

    public void FillResolutionDropdown()
    {
        //Get all possible resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        //Unity dropdowns work with string, thus we make a new string-based list and convert the resolutions to string
        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            //If the resolution is equal to our current resolution, remember it for later under currentResolutionIndex
            if (resolutions[i].width == Screen.currentResolution.width &&
            resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //Add all the options to the dropdown
        resolutionDropdown.AddOptions(resolutionOptions);

        //Adjust the default resolution selection to be equal to our current resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Used by the quality dropdown onChange
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Used by the fullscreen toggle onChange
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //Used by the resolution dropdown onChange
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Used by the SFXVolumeSlider onChange
    public void SetSFXVolume(float volume)
    {
        EffectsAudioMixer.audioMixer.SetFloat("SFXVolume", volume);

        //Save the current volume in PlayerPrefs for future sessions
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    //Used by the ambientVolume slider onChange
    public void SetAmbientVolume(float volume)
    {
        AmbientAudioMixer.audioMixer.SetFloat("AmbientVolume", volume);

        //Save the current volume in PlayerPrefs for future sessions
        PlayerPrefs.SetFloat("AmbientVolume", volume);
        PlayerPrefs.Save();
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
