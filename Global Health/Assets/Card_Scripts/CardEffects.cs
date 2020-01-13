using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{

    private List<ScriptableCard> cardDeck;

    public void Start()
    {
        cardDeck = GetComponent<CardDeck>().cardDeck;
    }

    public void ChangePopulation(ScriptableCard CardVariables)
    {
        int affectedCity = (int)CardVariables.affectedCity;
        int cardValue = (int)CardVariables.cardValue;
        bool cardBool = (bool)CardVariables.NegativeValue;

        GameWorld.Instance.cities[affectedCity].UpdatePopulation(cardValue, cardBool);
    }

    public void ChangeHealthCare(ScriptableCard CardVariables)
    {
        int affectedCity = (int)CardVariables.affectedCity;
        int cardValue = (int)CardVariables.cardValue;
        bool cardBool = (bool)CardVariables.NegativeValue;

        GameWorld.Instance.cities[affectedCity].UpdateHealthCare(cardValue, cardBool);
    }

    public void ConstructBuilding(ScriptableCard CardVariables)
    {

        int affectedCity = (int)CardVariables.affectedCity;
        string cardString = (string)CardVariables.AddedBuilding;
        int CardTime = (int)CardVariables.TurnCountdown;
        GameWorld.Instance.cities[affectedCity].ConstructBuilding(cardString,CardTime);
        cardDeck.Remove(CardVariables);
    }
}
