using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] menus;

    private int currentMenuNumber;
    private int newMenuNumber;

    public AudioSource startGame;
    public AudioSource quitGame;

    void Start()
    {
        //Initial values, this triggers the change method and defaults the scene to the main menu
        newMenuNumber = 0;
        currentMenuNumber = 99;
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundManager>().PlayMusic();
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
        startGame.PlayOneShot(startGame.clip, 1.0f);
        newMenuNumber = menuNumber;
    }

    public void StartGame()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        float duration = startGame.clip.length;
        startGame.PlayOneShot(startGame.clip, duration);

        //load the scene asynchrounously, it's important you set allowsceneactivation to false
        //in order to wait for the audioclip to finish playing
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("GameWorld");
        sceneLoading.allowSceneActivation = false;

        //wait for the audioclip to end
        yield return new WaitForSeconds(duration);
        //wait for the scene to finish loading (it will always stop at 0.9 when allowSceneActivation is false
        while (sceneLoading.progress < 0.9f) yield return null;
        //allow the scene to load
        sceneLoading.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        quitGame.PlayOneShot(quitGame.clip, 1.0f);
        Application.Quit();
    }
}
