using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedCard : MonoBehaviour
{
    public ScriptableCard linkedCard;
    public CardController cardController;


    private void Start()
    {
        cardController = FindObjectOfType<CardController>();
    }

    public void CardUsed()
    {
        if (cardController.CardsPlayed < cardController.MaxCardsPlayed)
        {
            cardController.PlayCard(linkedCard);
            Object.Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Max cards reached this turn");
        }
    }
}
