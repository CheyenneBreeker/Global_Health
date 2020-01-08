using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //    _audioSource = GetComponent<AudioSource>();
    //}

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic()
    {
        if (music.isPlaying) return;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

}
