using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update

    private bool isCurrentlyPaused;
    void Start()
    {
        isCurrentlyPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isCurrentlyPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        isCurrentlyPaused = !isCurrentlyPaused;
    }

    private void GoToMainMenu()
    {
        Debug.Log("GameController/GoToMainMenu() called.");
        //TODO: SceneManager.LoadScene("MainMenu");
    }
}
