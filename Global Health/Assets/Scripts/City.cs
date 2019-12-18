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

    protected int score = 0;

    private void Start()
    {
        UpdateCityUI();
    }

    private void SendPopulation()
    {
        GameWorld.Instance.NewPopulation(currentPopulation);
    }
    
    public void UpdateCityUI()
    {
        cityui.UpdateUI(currentPopulation,healthCare,deathrate,economy,casesPrevented,cureSucces);
    }
}
