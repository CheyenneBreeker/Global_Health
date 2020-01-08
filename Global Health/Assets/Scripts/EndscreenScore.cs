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

    int survivors;
    int deathrate;
    int buildings;

    public int multiplier = 4;

    int totalScore;

    public Text[] pop;
    public Text[] death;
    public Text[] building;

    public AudioSource screenshotButton;
    public AudioSource quitButton;

    // Start is called before the first frame update
    void Start()
    { 
        survivors = GameWorld.Instance.population;
        survivorsText.text = "Total Survivors: " + survivors.ToString();

        deathrate = GameWorld.Instance.deathrate;
        deathrateText.text = "Total Deathrate: " + deathrate.ToString();

        buildings = GameWorld.Instance.building;
        buildingsText.text = "Total Buildings: " + buildings.ToString();

        totalScore = survivors + buildings * multiplier - deathrate;

        totalScoreText.text = "Total Score: " + totalScore.ToString();

        for (int i = 0; i < GameWorld.Instance.cities.Length; i++)
        {
            pop[i].text = "Survivors: " + GameWorld.Instance.cities[i].currentPopulation.ToString();
            death[i].text = "Deathrate: " + GameWorld.Instance.cities[i].deathrate.ToString();
            building[i].text = "Buildings: " + GameWorld.Instance.cities[i].countBuilding.ToString();
        }

        Destroy(GameObject.Find("GameWorldCanvas"));
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundManager>().PlayMusic();
    }

    public void TakeScreenshot()
    {
        Debug.Log("Screenshot taken");
        screenshotButton.PlayOneShot(screenshotButton.clip, 1.0f);
        ScreenCapture.CaptureScreenshot("Endscreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        quitButton.PlayOneShot(quitButton.clip, 1.0f);
        Application.Quit();
    }
}
