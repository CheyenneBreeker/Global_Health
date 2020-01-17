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
    public int amountOfEffectsOnCity;

    private void Start()
    {
        correspondingCity = this.gameObject.GetComponent(typeof(City)) as City;
    }
    public void NextTurn()
    {
        deathChance = -1f + (((correspondingCity.healthCare * correspondingCity.drugResearch) /500) *0.2f);
        newPopulationChanges = (correspondingCity.currentPopulation * deathChance)/10;
        if (newPopulationChanges < 0)
            correspondingCity.deaths -= ((int)newPopulationChanges);
        else
            correspondingCity.newBorn += ((int)newPopulationChanges);
        newPopulation = correspondingCity.currentPopulation + (int)newPopulationChanges;
        correspondingCity.currentPopulation = newPopulation;
        CityWellBeing();
    }

    public void CityWellBeing()
    {
        correspondingCity.cityWellBeing = (correspondingCity.healthCare / amountOfEffectsOnCity) + (correspondingCity.drugResearch / amountOfEffectsOnCity) +
        (correspondingCity.economy / amountOfEffectsOnCity) + (correspondingCity.schooling / amountOfEffectsOnCity);
        correspondingCity.UpdateCityUI();

    }
}
