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

            //Game Scene
            case 1:
            cities[0] = GameObject.Find("Sea city").GetComponent<City>();
            cities[1] = GameObject.Find("River city").GetComponent<City>();
            cities[2] = GameObject.Find("Mountain city").GetComponent<City>();
            cities[3] = GameObject.Find("Forest city").GetComponent<City>();
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

    public Text worldPopulation;
    public Text playerMoney;
    public void UpdateGameUI()
    {
        playerMoney.text = "IMU: " + imu.ToString();
        worldPopulation.text = "World population: " + population.ToString();

    }
}
