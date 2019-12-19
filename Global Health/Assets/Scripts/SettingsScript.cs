using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer effectsAudioMixer;
    public AudioMixer ambientAudioMixer;

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
}
