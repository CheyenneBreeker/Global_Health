using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    // State Machine
    StateMachine stateMachine = new StateMachine();

    // UI elements
    public TurnCounter tCounter;
    public Button tButton;

    private void Start()
    {
        stateMachine.ChangeState(new CurrentTurnState(this));               
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void NextTurn()
    {
        stateMachine.ChangeState(new NextTurnState(this));
    }

    public void BeginTurn()
    {
        stateMachine.ChangeState(new CurrentTurnState(this));
    }
}
