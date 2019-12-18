using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] menus;

    private int currentMenuNumber;
    private int newMenuNumber;

    void Start()
    {
        newMenuNumber = 0;
    }

    void Update()
    {
        //Check if we got a differen menu number
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
        newMenuNumber = menuNumber;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameWorld");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
