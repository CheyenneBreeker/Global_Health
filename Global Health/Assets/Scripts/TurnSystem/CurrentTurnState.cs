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

        // Increases turnCount value, updates the counter text and enables the NextTurn button.
        owner.tCounter.IncreaseTurnCount();
        owner.tButton.gameObject.SetActive(true);

        owner.cardController.GetCards();
    }

    // Method which activates when the Enter method has been run through.
    public void Execute()
    {
        // Debug.Log("UPDATING CURRENT TURN STATE");
    }

    // Method which activates when the state is exited.
    public void Exit()
    {
        Debug.Log("EXITING CURRENT TURN STATE");

        // Disables the NextTurn button when exiting the CurrentTurn state.
        owner.tButton.gameObject.SetActive(false);
        owner.cardController.LoseCards();

        owner.eventCardDeck.EventTrigger();
    }
}
