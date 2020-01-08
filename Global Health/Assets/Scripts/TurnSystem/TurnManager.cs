using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    // State Machine.
    StateMachine stateMachine = new StateMachine();

    // Card Controller
    public CardController cardController;

    // UI elements.
    public TurnCounter tCounter;
    public Button tButton;

    public EventCardDeck eventCardDeck;

    public AudioSource beginTurn;
    public AudioSource nextTurn;

    // Sets the state to enter at the start of the game.
    private void Start()
    {
        stateMachine.ChangeState(new CurrentTurnState(this));               
    }

    // Updates the state that's currently active. 
    private void Update()
    {
        stateMachine.Update();
    }

    // Method to go to the NextTurnState.
    public void NextTurn()
    {
        nextTurn.PlayOneShot(nextTurn.clip, 1.0f);
        stateMachine.ChangeState(new NextTurnState(this));
    }

    // Method to go to the CurrentTurnState.
    public void BeginTurn()
    {
        beginTurn.PlayOneShot(beginTurn.clip, 1.0f);
        //remove cards on canvas
        foreach (Transform child in cardController.CardContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        cardController.CardsPlayed = 0;
        stateMachine.ChangeState(new CurrentTurnState(this));
        
    }
}
