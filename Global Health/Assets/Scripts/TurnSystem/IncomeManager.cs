using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the income that the player will receive over time, is a component of the turnmanager gameobject.
public class IncomeManager : MonoBehaviour
{
    // Default values
    public int defaultIncome = 5000;
    public float defaultTurnsTillIncome = 5;

    // Adjustable values
    public int currentIncome;
    public float currentTurnsTillIncome;

    // Instance to make it easier for other parts of the code to reach and adjust this script
    public static IncomeManager Instance { get; private set; }

    // UI Element we have to adjust depending on income and turns remaining untill that income
    public Text incomeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTurnsTillIncome = defaultTurnsTillIncome;
        currentIncome = defaultIncome;
        Instance = this;
        UpdateIncomeData();
    }

    // Called by the turn manager when going to the next turn.
    public void AdvanceTurn()
    {
        Debug.Log("AdvanceTurn called.");
        currentTurnsTillIncome--;

        UpdateIncomeData();
    }

    // Updates all the data within the Income Manager to be fully up to date, called by other functions after alterations.
    void UpdateIncomeData()
    {
        // Check if we should be giving the player money
        if (currentTurnsTillIncome <= 0)
        {
            // Add the money
            if (currentIncome > 0)
            {
                GameWorld.Instance.increaseIMU(currentIncome);
            }

            // Reset the values
            currentTurnsTillIncome = defaultTurnsTillIncome;
            currentIncome = defaultIncome;
        }

        // Update the UI
        string sAddition = "";
        if (currentTurnsTillIncome > 1) sAddition = "s";

        incomeText.text = "You will receive " + currentIncome + " IMU in " + currentTurnsTillIncome + " turn" + sAddition + ".";
    }

    // Public function to be called by events or anything inbetween to alter the income.
    public void AlterIncomeValue(string type, int value)
    {
        switch (type)
        {
            case "+":
                currentIncome += value;
                break;

            case "-":
                currentIncome -= value;
                break;

            case "/":
                currentIncome /= value;
                break;

            case "*":
                currentIncome *= value;
                break;

            default:
                Debug.Log("Operator type not found in IncomeManager.cs/AlterIncomeValues.");
                break;
        }

        UpdateIncomeData();
    }

    // Public function to be called by events or anything inbetween to alter the turns till income.
    public void AlterIncomeTurns(string type, int value)
    {
        switch (type)
        {
            case "+":
                currentTurnsTillIncome += value;
                break;

            case "-":
                currentTurnsTillIncome -= value;
                break;

            default:
                Debug.Log("Operator type not found in IncomeManager.cs/AlterIncomeTurns.");
                break;
        }

        UpdateIncomeData();
    }
}
