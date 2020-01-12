using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCounter : MonoBehaviour
{
    // Variables.
    [HideInInspector]
    public int turnCount;
    public int maxTurnCount;
    Text turnCountText;

    // Inits text object and text value.
    private void Start()
    {
        turnCountText = this.gameObject.GetComponent<Text>();
        turnCountText.text = "Week: " + turnCount + " / " + maxTurnCount;
    }

    // Method to increase the turnCount and updates text value afterwards.
    public void IncreaseTurnCount()
    {
        turnCount++;
        turnCountText.text = "Week: " + turnCount + " / " + maxTurnCount;
    }
}
