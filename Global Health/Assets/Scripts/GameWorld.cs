using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class GameWorld : MonoBehaviour
{
    public double imu;
    public int population;
    public GameObject[] cities;
    public static GameWorld Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        FindAllCities();
        UpdatePopulation();
        UpdateGameUI();
        
    }

    public void FindAllCities()
    {
        var objects = GameObject.FindGameObjectsWithTag("City");
        cities = new GameObject[objects.Length];
        cities = objects;
    }
    public void substractIMU(double spend)
    {
        imu -= spend;
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
            cities[i].SendMessage("SendPopulation");
        }
        yield return new WaitForSeconds(delayValue);
        worldPopulation.text = "World population: " + population.ToString();

    }

    public Text worldPopulation;
    public Text playerMoney;
    void UpdateGameUI()
    {
        playerMoney.text = "IMU: " + imu.ToString();
        worldPopulation.text = "World population: " + population.ToString();

    }
}
