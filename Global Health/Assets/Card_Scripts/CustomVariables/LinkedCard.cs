using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (cardController.selectedCard == gameObject)
            {
                cardController.PlayCard(linkedCard);
                Object.Destroy(this.gameObject);
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

    public void Update()
    {
        if (cardController.selectedCard == gameObject)
        {
            LeanTween.moveY(gameObject, 40 + 30, 0.25f);
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }
        else
        {
            LeanTween.moveY(gameObject, 40, 0.25f);
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }
}
