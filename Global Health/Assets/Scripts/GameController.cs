using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
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
        Debug.Log("GameController/GoToMainMenu() called.");
        //TODO: SceneManager.LoadScene("MainMenu");
    }
}
