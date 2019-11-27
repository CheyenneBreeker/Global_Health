using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnState : IState
{
    TurnManager owner;

    public NextTurnState(TurnManager owner) { this.owner = owner; }

    public void Enter()
    {
        Debug.Log("ENTERING CURRENT TURN STATE");
    }

    public void Execute()
    {
        Debug.Log("UPDATING CURRENT TURN STATE");
    }

    public void Exit()
    {
        Debug.Log("EXITING CURRENT TURN STATE");
    }
}
