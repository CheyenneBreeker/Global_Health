using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pausePanel;

    public AudioSource togglePause;

    public AudioSource goToMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // togglePause button sound
        togglePause.PlayOneShot(togglePause.clip, 1.0f);

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
        // goToMenu button sound
        goToMenu.PlayOneShot(goToMenu.clip, 1.0f);

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
