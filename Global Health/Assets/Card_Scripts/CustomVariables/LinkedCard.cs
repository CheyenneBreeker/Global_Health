using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkedCard : MonoBehaviour
{
    public ScriptableCard linkedCard;
    public CardController cardController;

    private bool cardIsBeingPlayed;

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
                StartCoroutine(ActivateCard());
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
        cardIsBeingPlayed = true;
        cardController.selectedCard = null;
        LeanTween.moveY(this.gameObject, gameObject.transform.position.y - 150, 0.9f).setEaseInOutCubic();

        yield return new WaitForSeconds(1);

        cardController.PlayCard(linkedCard);
        Object.Destroy(this.gameObject);
    }

    public void Update()
    {
        if (cardController.selectedCard == gameObject)
        {
            LeanTween.moveY(gameObject, 40 + 30, 0.25f);
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }
        else if(!cardIsBeingPlayed)
        {
            LeanTween.moveY(gameObject, 40, 0.25f);
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }
}
