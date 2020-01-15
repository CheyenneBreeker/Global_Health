using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBonus : MonoBehaviour
{
    public int healthCareBonus;
    public int economyBonus;
    public int schoolingBonus;
    public int cureSuccesBonus;
    void Start()
    {
        City correspondingCity = gameObject.GetComponentInParent(typeof(City)) as City;

        correspondingCity.healthCare += healthCareBonus;
        correspondingCity.economy += economyBonus;
        correspondingCity.schooling += schoolingBonus;
        correspondingCity.drugResearch += cureSuccesBonus;
        correspondingCity.UpdateCityUI();
    }
}
