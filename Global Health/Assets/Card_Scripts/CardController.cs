using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardController : MonoBehaviour
{
    public GameObject CardUI;
    public GameObject CardContainer;
    public int CardsPerTurn = 5;
    public List<ScriptableCard> PlayerDeck;
    private List<ScriptableCard> cardDeck;
    public List<GameObject> CardsInHand;
    public  List<ScriptableCard> UsedCards;
    public GameObject selectedCard;
    public int CardsPlayed;
    public int MaxCardsPlayed = 3;

    private void Start()
    {
        cardDeck = GetComponent<CardDeck>().cardDeck;
        GetCards();
    }

    public void GetCards()
    {
        for (int i = 0; i < CardsPerTurn; i++)
        {
            ScriptableCard randomCard = cardDeck[Random.Range(0, cardDeck.Count)];

            PlayerDeck.Add(randomCard);
        }
        DisplayCards(PlayerDeck);
    }

    public void LoseCards()
    {
        PlayerDeck.Clear();
        CardsInHand.Clear();
    }

    private void DisplayCards(List<ScriptableCard> PlayerDeck)
    {
        float spawnPosition = Screen.width/3;
        foreach (var Card in PlayerDeck)
        {
            GameObject playingCard = CardUI;
            
            playingCard.transform.Find("CardName").GetComponent<Text>().text = Card.cardName.ToString();
            playingCard.transform.Find("CardCost").GetComponent<Text>().text = "C: "+ Card.cardCost.ToString();
            playingCard.transform.Find("CardSummary").GetComponent<Text>().text = Card.cardFlavorText.ToString();
            playingCard.GetComponent<LinkedCard>().linkedCard = Card ;

            GameObject NewCard = Instantiate(playingCard, new Vector3(Screen.width, CardContainer.transform.position.y + playingCard.GetComponent<RectTransform>().rect.height / 2, CardContainer.transform.position.z),Quaternion.identity);
            LeanTween.moveX(NewCard, spawnPosition, 1f).setEaseOutCubic();

            NewCard.transform.parent = CardContainer.transform;
            spawnPosition += NewCard.GetComponent<RectTransform>().rect.width;
            CardsInHand.Add(NewCard);
        }
    }

    public void PlayCard(ScriptableCard PlayedCard)
    {
        object[] cardvariables = new object[4];
        cardvariables[0] = PlayedCard.affectedCity;
        cardvariables[1] = PlayedCard.cardValue;
        cardvariables[2] = PlayedCard.NegativeValue;
        cardvariables[3] = PlayedCard.AddedBuilding;
        this.SendMessage(PlayedCard.CardEffect.ToString(), cardvariables, SendMessageOptions.RequireReceiver);
        GameWorld.Instance.substractIMU(PlayedCard.cardCost);
        UsedCards.Add(PlayedCard);
        PlayerDeck.Remove(PlayedCard);
        CardsPlayed++;
    }
}
