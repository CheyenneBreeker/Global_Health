using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndscreenScore : MonoBehaviour
{
    public Text totalScoreText;
    public Text survivorsText;
    public Text deathrateText;
    public Text buildingsText;

    public int survivors;
    public int deathrate;
    public int buildings;

    public int multiplier = 4;

    public int totalScore;

    // Start is called before the first frame update
    void Start()
    {

        //countBuilding = buildings.transform.childCount;

        survivorsText.text = "Survivors: " + survivors.ToString();

        deathrateText.text = "Deathrate: " + deathrate.ToString();
        buildingsText.text = "Buildings: " + buildings.ToString();

        totalScore = survivors + buildings * multiplier - deathrate;

        totalScoreText.text = "Total Score: " + totalScore.ToString();
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
