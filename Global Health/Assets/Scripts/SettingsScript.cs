using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer effectsAudioMixer;
    public AudioMixer ambientAudioMixer;

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    void Start()
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

        //Adjust the default resolution to be equal to our current resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetSFXVolume(float volume)
    {
        effectsAudioMixer.SetFloat("SFXVolume", volume);
    }

    public void SetAmbientVolume(float volume)
    {
        ambientAudioMixer.SetFloat("AmbientVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
