using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] menus;

    private int currentMenuNumber;
    private int newMenuNumber;

    [SerializeField]
    private AudioClip buttonClicksSFX;
    [SerializeField]
    private AudioClip music;

    void Start()
    {
        //Initial values, this triggers the change method and defaults the scene to the main menu
        newMenuNumber = 0;
        currentMenuNumber = 99;
        AudioManager.Instance.PlayMusicWithFade(music);
    }

    void Update()
    {
        //Check if we got a different menu number
        if (newMenuNumber == currentMenuNumber)
        {
            return;
        }

        //Make it the new current number and change the menu to it
        currentMenuNumber = newMenuNumber;
        ChangeMenu(currentMenuNumber);
    }

    //View the menu with the same menuNumber in de menus array
    public void ChangeMenu(int menuNumber)
    {
        //Deactivate all opened menus
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        //Activate the correct menu
        menus[menuNumber].SetActive(true);
    }

    //Set the new menu number (called by buttons)
    public void SwitchMenuNumber(int menuNumber)
    {
        //startGame.PlayOneShot(startGame.clip, 1.0f);
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        newMenuNumber = menuNumber;
    }

    public void StartGame()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SceneManager.LoadScene("GameWorld");
    }

    public void QuitGame()
    {
        //quitGame.PlayOneShot(quitGame.clip, 1.0f);
        Application.Quit();
    }
}
