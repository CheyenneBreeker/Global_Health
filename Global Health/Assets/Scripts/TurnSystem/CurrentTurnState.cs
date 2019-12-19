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

        owner.StartCoroutine(owner.TurnFeedback("Turn Begins"));

        // Increases turnCount value, updates the counter text and enables the NextTurn button.
        owner.turnCounter.IncreaseTurnCount();
        owner.turnButton.gameObject.SetActive(true);

        owner.cardController.GetCards();
    }

    // Method which activates when the Enter method has been run through.
    public void Execute()
    {
        Debug.Log("UPDATING CURRENT TURN STATE");
    }

    // Method which activates when the state is exited.
    public void Exit()
    {
        Debug.Log("EXITING CURRENT TURN STATE");

        owner.StartCoroutine(owner.TurnFeedback("Turn Ended"));

        // Disables the NextTurn button when exiting the CurrentTurn state.
        owner.turnButton.gameObject.SetActive(false);
        owner.cardController.LoseCards();

        owner.eventCardDeck.EventTrigger();
    }
}
