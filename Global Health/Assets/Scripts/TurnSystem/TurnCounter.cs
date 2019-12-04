using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCounter : MonoBehaviour
{
    int turnCount;
    Text turnCountText;

    private void Start()
    {
        turnCountText = this.gameObject.GetComponent<Text>();
        turnCountText.text = "Week: " + turnCount;
    }

    public void IncreaseTurnCount()
    {
        turnCount++;
        turnCountText.text = "Week: " + turnCount;
    }
}
