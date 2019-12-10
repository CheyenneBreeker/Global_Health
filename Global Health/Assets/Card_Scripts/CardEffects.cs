using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{

    public void ChangePopulation( object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];
        bool cardBool = (bool)CardVariables[2];

        GameWorld.Instance.cities[affectedCity].UpdatePopulation(cardValue, cardBool);
    }

    public void ChangeHealthCare(object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];
        bool cardBool = (bool)CardVariables[2];

        GameWorld.Instance.cities[affectedCity].UpdateHealthCare(cardValue, cardBool);
    }

    public void ConstructBuilding(object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];
        string cardString = (string)CardVariables[2];

        GameWorld.Instance.cities[affectedCity].ConstructBuilding(cardString);
    }
}
