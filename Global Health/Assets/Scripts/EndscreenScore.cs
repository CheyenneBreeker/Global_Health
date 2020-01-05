using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndscreenScore : MonoBehaviour
{
    public Text survivorsText;
    public Text deathrateText;
    public Text buildingsText;

    public int survivors;
    public int deathrate;
    public int buildings;

    // Start is called before the first frame update
    void Start()
    {
        survivors = PlayerPrefs.GetInt("population");
        deathrate = PlayerPrefs.GetInt("deathrate");
        buildings = PlayerPrefs.GetInt("buildings");

        survivorsText.text = "Survivors: " + survivors.ToString();
        deathrateText.text = "Deathrate: " + deathrate.ToString();
        buildingsText.text = "Buildings: " + buildings.ToString();
    }

    public void TakeScreenshot()
    {
        Debug.Log("Screenshot taken");
        ScreenCapture.CaptureScreenshot("Endscreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
