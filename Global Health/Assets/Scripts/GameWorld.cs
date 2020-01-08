using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWorld : MonoBehaviour
{
    public double imu;
    public int population;
    public int deathrate;
    public int building;
    public City[] cities;
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
        UpdatePopulation();
        UpdateDeathrate();
        UpdateBuilding();
        UpdateGameUI();
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

    public void UpdateDeathrate()
    {
        StartCoroutine(SendDeathrateRequest());
    }

    public void NewDeathrate(int newdeathrate)
    {
        deathrate += newdeathrate;
    }

    public float delayValueDeathrate;
    public IEnumerator SendDeathrateRequest()
    {
        deathrate = 0;

        for (int i = 0; i < cities.Length; i++)
        {
            cities[i].SendDeathrate();
        }
        yield return new WaitForSeconds(delayValueDeathrate);
        Debug.Log("death: " + deathrate);
    }


    public void UpdateBuilding()
    {
        StartCoroutine(SendBuildingRequest());
    }

    public void NewBuilding(int newbuilding)
    {
        building += newbuilding;
    }

    public float delayValueBuilding;
    public IEnumerator SendBuildingRequest()
    {
        building = 0;

        for (int i = 0; i < cities.Length; i++)
        {
            cities[i].SendBuilding();
        }
        yield return new WaitForSeconds(delayValueBuilding);
        Debug.Log("buildings: " + building);
    }

    public Text worldPopulation;
    public Text playerMoney;
    public void UpdateGameUI()
    {
        playerMoney.text = "IMU: " + imu.ToString();
        worldPopulation.text = "World population: " + population.ToString();
        Debug.Log("pop: " + population);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToScene();
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene("Endscreen");
    }
}
