using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public CityUI cityui;
    public int currentPopulation;
    public int healthCare;
    public int deathrate;
    public string economy;
    public int casesPrevented;
    public int cureSucces;
    public Transform buildings;
    int countBuilding;

    private void Start()
    {
        UpdateCityUI();
    }

    public void SendPopulation()
    {
        GameWorld.Instance.NewPopulation(currentPopulation);
    }
    
    public void UpdatePopulation(int n_population, bool substract)
    {
        if (substract)
            currentPopulation -= n_population;
        else
            currentPopulation += n_population;

        UpdateCityUI();
    }

    public void SendDeathrate()
    {
        GameWorld.Instance.NewDeathrate(deathrate);
    }

    public void UpdateDeathrate(int n_deathrate, bool substract)
    {
        if (substract)
            deathrate -= n_deathrate;
        else
            deathrate += n_deathrate;

        UpdateCityUI();
    }

    public void UpdateHealthCare(int n_healthcare, bool substract)
    {
        if (substract)
            healthCare -= n_healthcare;
        else
            healthCare += n_healthcare;

        UpdateCityUI();
    }

    public void ConstructBuilding(string buildingName)
    {
        Debug.Log("Building called");

        foreach (Transform building in buildings)
        {

            if (building.name == buildingName)
            {
                Debug.Log("Building found");
                building.gameObject.SetActive(true);
                countBuilding++;
            }
        }

        SendBuilding();
    }


    public void SendBuilding()
    {
        Debug.Log(countBuilding);
        GameWorld.Instance.NewBuilding(countBuilding);
    }

    public void UpdateBuilding(int n_building, bool substract)
    {
        if (substract)
            countBuilding -= n_building;
        else
            countBuilding += n_building;
    }

    public void UpdateCityUI()
    {
        cityui.UpdateUI(currentPopulation,healthCare,deathrate,economy,casesPrevented,cureSucces);
    }
}
