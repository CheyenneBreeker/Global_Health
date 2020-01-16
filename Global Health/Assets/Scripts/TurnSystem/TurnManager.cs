using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    // State Machine.
    StateMachine stateMachine = new StateMachine();

    // Card Controller
    public CardController cardController;

    // UI elements.
    public TurnCounter turnCounter;
    public Button turnButton;
    public Text turnFeedback;

    public EventCardDeck eventCardDeck;

    [SerializeField]
    private AudioClip buttonClicksSFX;

    // Sets the state to enter at the start of the game.
    private void Start()
    {
        stateMachine.ChangeState(new CurrentTurnState(this));
    }

    // Updates the state that's currently active. 
    private void Update()
    {
        stateMachine.Update();
        if (turnCounter.turnCount > turnCounter.maxTurnCount)
        {
            SceneManager.LoadScene("Endscreen");
        }
    }

    // Method to go to the NextTurnState.
    public void NextTurn()
    {
        stateMachine.ChangeState(new NextTurnState(this));
    }

    // Method to go to the CurrentTurnState.
    public void BeginTurn()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);

        //remove cards on canvas
        foreach (Transform child in cardController.CardContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //Advance Building construction by 1
        foreach(GameObject Building in GameWorld.Instance.totalBuildings)
        {
            Building.GetComponent<BuildingConstruction>().BuildingCountdown();
        }

        //Advance the IncomeManager by 1
        if (IncomeManager.Instance)
        {
            IncomeManager.Instance.AdvanceTurn();
        }

        cardController.CardsPlayed = 0;
        stateMachine.ChangeState(new CurrentTurnState(this));
    }

    public IEnumerator TurnFeedback(string text)
    {
        turnFeedback.text = text;
        turnFeedback.gameObject.GetComponent<Animator>().Play("TurnFeedback_Action");
        yield return new WaitForSeconds(1.5f);
        turnFeedback.gameObject.GetComponent<Animator>().Play("TurnFeedback_Idle");
    }
}
