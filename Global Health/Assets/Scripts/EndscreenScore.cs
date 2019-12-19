using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndscreenScore : MonoBehaviour
{
    public Text survivorsText;

    public int survivors;

    // Start is called before the first frame update
    void Start()
    {
        survivors = PlayerPrefs.GetInt("Player population");

        //scoreText.text = "Score: 0";
        //casualtiesText.text = "Casualties: 0";
        survivorsText.text = "Survivors: " + survivors.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameWorld");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
