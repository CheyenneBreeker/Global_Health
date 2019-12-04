using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnState : IState
{
    TurnManager owner;
    TurnCounter tCounter;

    public NextTurnState(TurnManager owner) { this.owner = owner; }

    public void Enter()
    {
        Debug.Log("ENTERING NEXT TURN STATE");
        tCounter.IncreaseTurnCount();
        Execute();
    }

    public void Execute()
    {
        Debug.Log("UPDATING NEXT TURN STATE");
        Exit();
    }

    public void Exit()
    {
        Debug.Log("EXITING NEXT TURN STATE");
        owner.BeginTurn();
    }
}
