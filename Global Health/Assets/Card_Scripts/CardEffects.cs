using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{

    public void ChangePopulation( object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];

        GameWorld.Instance.cities[affectedCity].GetComponent<City>().currentPopulation += cardValue;
        Debug.Log(GameWorld.Instance.cities[affectedCity].GetComponent<City>().currentPopulation);
    }

    public void ChangeHealthCare(object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];

        GameWorld.Instance.cities[affectedCity].GetComponent<City>().healthCare += cardValue;
        Debug.Log(GameWorld.Instance.cities[affectedCity].GetComponent<City>().healthCare);
    }
}
