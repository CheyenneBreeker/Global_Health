using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityUI : MonoBehaviour
{
    public GameObject cityDetailsUI;
    public Text population;
    public Text healthCare;
    public Text deathrate;
    public Text newBorn;
    public Text economy;
    public Text cureSucces;
    public void UpdateUI(int n_population, int n_healthcare, int n_deathrate, int n_economy, int n_casesPrevented, int n_cureSucces)
    {
        population.text = "Population: " + n_population.ToString();
        healthCare.text = "Healthcare: " + n_healthcare.ToString() + "%";
        deathrate.text = "Deaths : " + n_deathrate.ToString();
        economy.text = "Economy: " + n_economy.ToString() + "%";
        newBorn.text = "New born: " + n_casesPrevented.ToString();
        cureSucces.text = "Cure succes: " + n_cureSucces.ToString() + "%";
    }

    //Turning on the UI in gameworld
    public bool isUiActive;
    void OnMouseDown()
    {
        if (!isUiActive)
        {
            isUiActive = true;
            cityDetailsUI.SetActive(true);
        }
        else
        {
            isUiActive = false;
            cityDetailsUI.SetActive(false);
        }
    }
}
