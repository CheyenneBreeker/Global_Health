using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnCounter : MonoBehaviour
{
    // Variables.
    public int turnCount;
    Text turnCountText;

    // Inits text object and text value.
    private void Start()
    {
        turnCountText = this.gameObject.GetComponent<Text>();
        turnCountText.text = "Week: " + turnCount;
    }

    // Method to increase the turnCount and updates text value afterwards.
    public void IncreaseTurnCount()
    {

        turnCount++;
        turnCountText.text = "Week: " + turnCount;

        if (turnCount > 30)
        {
            turnCountText.enabled = false;
        }
    }
}
