using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnState : IState
{
    TurnManager owner;

    public NextTurnState(TurnManager owner) { this.owner = owner; }

    public void Enter()
    {
        Debug.Log("ENTERING NEXT TURN STATE");
    }

    public void Execute()
    {
        Debug.Log("UPDATING NEXT TURN STATE");

        // Temporary way to return to CurrentTurnState
        if (Input.GetKeyDown(KeyCode.Space))
        {
            owner.BeginTurn();
        }
    }

    public void Exit()
    {
        Debug.Log("EXITING NEXT TURN STATE");
    }
}
