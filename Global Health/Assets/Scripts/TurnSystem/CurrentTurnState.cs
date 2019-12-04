using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTurnState : IState
{
    TurnManager owner;

    public CurrentTurnState(TurnManager owner) { this.owner = owner; }

    public void Enter()
    {
        Debug.Log("ENTERING CURRENT TURN STATE");
        Execute();
    }

    public void Execute()
    {
        Debug.Log("UPDATING CURRENT TURN STATE");
        Exit();
    }

    public void Exit()
    {
        Debug.Log("EXITING CURRENT TURN STATE");
    }
}
