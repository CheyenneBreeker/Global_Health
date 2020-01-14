using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pausePanel;

    [SerializeField]
    private AudioClip buttonClicksSFX;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // Pause button sound
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);

        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GoToMainMenu()
    {
        // Menu button sound
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
