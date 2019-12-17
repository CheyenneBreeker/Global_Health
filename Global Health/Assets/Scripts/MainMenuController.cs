using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameWorld");
    }

    public void ToggleOptionMenu()
    {
        Debug.Log("Toggle option menu.");
    }

    public void ToggleCredits()
    {
        Debug.Log("Toggle credits.");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
