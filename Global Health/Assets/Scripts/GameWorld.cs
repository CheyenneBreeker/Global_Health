using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWorld : MonoBehaviour
{
    public double imu;
    public int population;
    public City[] cities;
    public static GameWorld Instance { get; private set; }
    private void Start()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        UpdatePopulation();
        UpdateGameUI();
    }

    private void OnLevelWasLoaded(int levelNumber)
    {
        switch(levelNumber)
        {
            //Main Menu
            case 0:
            DestroyImmediate(gameObject);
            break;

            default:
            break;
        }
    }
    public void substractIMU(double units)
    {
        imu -= units;
        playerMoney.text = "IMU: " + imu.ToString();
    }

    public void increaseIMU(double units)
    {
        imu += units;
        playerMoney.text = "IMU: " + imu.ToString();
    }

    public void UpdatePopulation()
    {
        StartCoroutine(SendPopulationRequest());
    }

    public void NewPopulation(int newpopulation)
    {
        population += newpopulation;
    }

    public float delayValue;
    public IEnumerator SendPopulationRequest()
    {
        population = 0;
        for (int i = 0; i < cities.Length; i++)
        {
            cities[i].SendPopulation();
        }
        yield return new WaitForSeconds(delayValue);
        worldPopulation.text = "World population: " + population.ToString();

    }

    public void UpdateCities()
    {
        for (int i = 0; i < cities.Length; i++)
        {
            cities[i].GetNewData();
        }
    }

    public Text worldPopulation;
    public Text playerMoney;
    public void UpdateGameUI()
    {
        playerMoney.text = "IMU: " + imu.ToString();
        worldPopulation.text = "World population: " + population.ToString();

    }
}
