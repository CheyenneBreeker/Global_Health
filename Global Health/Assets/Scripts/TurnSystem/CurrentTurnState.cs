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
        owner.tCounter.IncreaseTurnCount();
        owner.tButton.gameObject.SetActive(true);
    }

    public void Execute()
    {
        Debug.Log("UPDATING CURRENT TURN STATE");
    }

    public void Exit()
    {
        Debug.Log("EXITING CURRENT TURN STATE");
        owner.tButton.gameObject.SetActive(false);
    }
}
