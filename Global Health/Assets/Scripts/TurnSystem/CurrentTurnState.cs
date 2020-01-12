using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTurnState : IState
{
    // Inits TurnManager class.
    TurnManager owner;
    public CurrentTurnState(TurnManager owner) { this.owner = owner; }

    // Method which activates when the state is entered.
    public void Enter()
    {
        Debug.Log("ENTERING CURRENT TURN STATE");

        if (owner.turnCounter.maxTurnCount - owner.turnCounter.turnCount <= 5)
        {
            owner.StartCoroutine(owner.TurnFeedback(owner.turnCounter.maxTurnCount - owner.turnCounter.turnCount + " Turns Remaining"));
        }
        else
        {
            owner.StartCoroutine(owner.TurnFeedback("Turn " + (owner.turnCounter.turnCount + 1)));
        }

        // Increases turnCount value, updates the counter text and enables the NextTurn button.
        owner.turnCounter.IncreaseTurnCount();
        owner.turnButton.gameObject.SetActive(true);
        owner.cardController.GetCards();
    }

    // Method which activates when the Enter method has been run through.
    public void Execute()
    {
        
    }

    // Method which activates when the state is exited.
    public void Exit()
    {
        Debug.Log("EXITING CURRENT TURN STATE");

        owner.StartCoroutine(owner.TurnFeedback("Turn Ended"));

        // Disables the NextTurn button when exiting the CurrentTurn state.
        owner.turnButton.gameObject.SetActive(false);
        owner.cardController.LoseCards();
        GameWorld.Instance.UpdateCities();
        owner.eventCardDeck.EventTrigger();
    }
}
