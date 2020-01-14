using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region Static Instance
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned AudioManager", typeof(AudioManager))
                        .GetComponent<AudioManager>();
                }
            }

            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    #region Fields
    private AudioSource musicSource;
    private AudioSource musicSource2;

    private AudioSource sfxSource;

    private bool firstMusicSourceIsPlaying;
    #endregion

    public AudioMixerGroup AmbientAudioMixer;
    public AudioMixerGroup EffectsAudioMixer;

    private void Awake()
    {
        // Make sure we don't destroy this instance
        DontDestroyOnLoad(this.gameObject);

        // Create audio sources, and save them as references
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        musicSource.outputAudioMixerGroup = AmbientAudioMixer;
        musicSource2.outputAudioMixerGroup = AmbientAudioMixer;

        sfxSource.outputAudioMixerGroup = EffectsAudioMixer;

        // Loop the music track
        musicSource.loop = true;
        musicSource2.loop = true;

    }

    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        // Determine which source is active
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));
    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {

        // Make sure the source is active and playing
        if (!activeSource.isPlaying)
        {
            activeSource.Play();
        }

        float t = 0.0f;

        // Fade out
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();

        // Fade in
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime);
            yield return null;
        }
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayEventSFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    ////Used by the SFXVolumeSlider onChange
    //public void SetSFXVolume(float volume)
    //{
    //    EffectsAudioMixer.audioMixer.SetFloat("SFXVolume", volume);

    //    //Save the current volume in PlayerPrefs for future sessions
    //    PlayerPrefs.SetFloat("SFXVolume", volume);
    //    PlayerPrefs.Save();
    //}

    ////Used by the ambientVolume slider onChange
    //public void SetAmbientVolume(float volume)
    //{
    //    AmbientAudioMixer.audioMixer.SetFloat("AmbientVolume", volume);

    //    //Save the current volume in PlayerPrefs for future sessions
    //    PlayerPrefs.SetFloat("AmbientVolume", volume);
    //    PlayerPrefs.Save();
    //}
}
