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
    public TurnCounter tCounter;
    public Button tButton;

    public EventCardDeck eventCardDeck;

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
        if (tCounter.turnCount > 30)
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        //float duration = nextTurn.clip.length;
        float duration = 1;
        nextTurn.PlayOneShot(nextTurn.clip, duration);

        //load the scene asynchrounously, it's important you set allowsceneactivation to false
        //in order to wait for the audioclip to finish playing
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("Endscreen");
        sceneLoading.allowSceneActivation = false;

        //wait for the audioclip to end
        yield return new WaitForSeconds(duration);
        //wait for the scene to finish loading (it will always stop at 0.9 when allowSceneActivation is false
        while (sceneLoading.progress < 0.9f) yield return null;
        //allow the scene to load
        sceneLoading.allowSceneActivation = true;
    }

    // Method to go to the NextTurnState.
    public void NextTurn()
    {
        stateMachine.ChangeState(new NextTurnState(this));
    }

    // Method to go to the CurrentTurnState.
    public void BeginTurn()
    {
        //remove cards on canvas
        foreach (Transform child in cardController.CardContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        cardController.CardsPlayed = 0;
        stateMachine.ChangeState(new CurrentTurnState(this));
        
    }
}
