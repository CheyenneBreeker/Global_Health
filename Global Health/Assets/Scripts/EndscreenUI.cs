using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndscreenUI : MonoBehaviour
{
    public Button quitBtn;

    public Text endScore;
    public Text casualties;
    public Text survivors;

    int surv;

    City city;
    GameWorld gameWorld;

    // Start is called before the first frame update
    void Start()
    {
        endScore.text = "Highscore: 0";
        casualties.text = "Casualties: 0";
        survivors.text = "Survivors: 0";

        Button btn = quitBtn.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);
    }

    public void UpdateScores()
    {

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("GameWorld");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
