using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();

    private void Start()
    {
        stateMachine.ChangeState(new CurrentTurnState(this));               
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
