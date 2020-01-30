using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    private CityUI cityui;
    private CityLogic cityLogic;
    public int cityWellBeing;
    public int currentPopulation;
    public int healthCare;
    public int economy;
    public int schooling;
    public int deaths; 
    public int newBorn;
    public int drugResearch;
    public Transform buildings;
    public int countBuilding;
    public GameObject boxPrefab;

    private void Start()
    {
        cityui = this.gameObject.GetComponent(typeof(CityUI)) as CityUI;
        cityLogic = this.gameObject.GetComponent(typeof(CityLogic)) as CityLogic;
        cityLogic.CityWellBeing();
        UpdateCityUI();
    }

    public void SendPopulation()
    {
        GameWorld.Instance.NewPopulation(currentPopulation);
    }
    public void GetNewData()
    {
        cityLogic.NextTurn();
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
        GameWorld.Instance.NewDeathrate(deaths);
    }

    public void UpdateDeathrate(int n_deaths, bool substract)
    {
        if (substract)
            deaths -= n_deaths;
        else
            deaths += n_deaths;

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

    public void ConstructBuilding(string buildingName, int BuildTime)
    {
        Debug.Log("Building called");

        foreach (Transform building in buildings)
        {

            if (building.name == buildingName)
            {
                Debug.Log("Building found");

                // Create the box and add the building to the box effect to have it open up at the right time
                GameObject createdBox = Instantiate(boxPrefab, new Vector3(building.gameObject.transform.position.x, 0.6f, building.gameObject.transform.position.z), Quaternion.identity);
                createdBox.GetComponent<BoxEffectScript>().buildingToCover = building.gameObject;
                countBuilding++;
                SendBuilding();

                if (building.gameObject.GetComponent<BuildingConstruction>().CountdownStarted == false)
                {
                    building.gameObject.GetComponent<BuildingConstruction>().Turncountdown = BuildTime;
                    building.gameObject.GetComponent<BuildingConstruction>().CountdownStarted = true;
                }
            }
            else
            {
                Debug.Log("Did not find Building: " + buildingName);
            }
        }
    }

    public void SendBuilding()
    {
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
        cityui.UpdateUI(cityWellBeing,currentPopulation, healthCare, deaths, economy, newBorn, drugResearch);
    }
}
