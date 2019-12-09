using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCounter : MonoBehaviour
{
    // Variables.
    int turnCount;
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

        if (turnCount > 1)
        {
            turnCountText.text = "Week: " + turnCount;
        }
    }
}
