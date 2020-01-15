using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkedCard : MonoBehaviour
{
    public ScriptableCard linkedCard;
    public CardController cardController;

    private bool cardIsBeingPlayed;
    private float amountSelectedCardRaisedVertically = 30;
    private GameObject currentlySelectedCard;

    private void Start()
    {
        cardController = FindObjectOfType<CardController>();
    }

    public void CardUsed()
    {
        if (cardController.CardsPlayed < cardController.MaxCardsPlayed)
        {
            if (cardController.selectedCard == gameObject && cardIsBeingPlayed == false)
            {
                if (linkedCard.cardCost < GameWorld.Instance.imu)
                {
                    StartCoroutine(ActivateCard());
                }
                else
                {
                    Debug.Log("Card is too expensive.");
                }
            }
            else
            {
                cardController.selectedCard = gameObject;
            }
        }
        else
        {
            Debug.Log("Max cards reached this turn");
        }
    }

    IEnumerator ActivateCard()
    {
        // Start the animation of the card
        cardIsBeingPlayed = true;
        cardController.selectedCard = null;
        LeanTween.moveY(this.gameObject, gameObject.transform.position.y - 150, 0.8f).setEaseInOutCubic();

        yield return new WaitForSeconds(1);

        // When out of view, play the effect of the card and remove it from the deck.
        cardController.PlayCard(linkedCard);
        Object.Destroy(this.gameObject);
    }

    public void FixedUpdate()
    {
        currentlySelectedCard = cardController.selectedCard;

        // Make the card slightly hover when it's selected
        if (currentlySelectedCard == gameObject)
        {
            LeanTween.moveY(gameObject, 40 + amountSelectedCardRaisedVertically, 0.2f);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        // Return the card to its original position when selection gets removed (unless it is currently being played)
        else if (!cardIsBeingPlayed)
        {
            LeanTween.moveY(gameObject, 40, 0.2f);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);

        }
    }
}
