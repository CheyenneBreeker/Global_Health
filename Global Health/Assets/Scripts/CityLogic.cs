using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityLogic : MonoBehaviour
{
    private float newPopulationChanges;
    private int newPopulation;
    private int newBorns;
    private float deathChance;
    private City correspondingCity;

    private void Start()
    {
        correspondingCity = this.gameObject.GetComponent(typeof(City)) as City;
    }
    public void NextTurn()
    {
        deathChance = -1f + (((correspondingCity.healthCare * correspondingCity.cureSucces) /500) *0.2f);
        newPopulationChanges = (correspondingCity.currentPopulation * deathChance)/10;
        if (newPopulationChanges < 0)
            correspondingCity.deaths += ((int)newPopulationChanges);
        else
            correspondingCity.newBorn += ((int)newPopulationChanges);
        newPopulation = correspondingCity.currentPopulation + (int)newPopulationChanges;
        correspondingCity.currentPopulation = newPopulation;
        correspondingCity.UpdateCityUI();
    }
}
