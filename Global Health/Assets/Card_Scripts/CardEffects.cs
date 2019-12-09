using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{

    public void ChangePopulation( object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];

        Debug.Log("ChangedThePopulation.");
        GameWorld.Instance.cities[affectedCity].GetComponent<City>().currentPopulation += cardValue;
    }

    public void ChangeHealthcare(object[] CardVariables)
    {
        int affectedCity = (int)CardVariables[0];
        int cardValue = (int)CardVariables[1];

        Debug.Log("ChangedThePopulation.");
        GameWorld.Instance.cities[affectedCity].GetComponent<City>().healthCare += cardValue;
    }
}
