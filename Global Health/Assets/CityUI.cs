using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityUI : MonoBehaviour
{
    public GameObject cityDetailsUI;
    public void UpdateUI()
    {
        //TODO: Update ui information -> population, deathrate
    }

    //Turning on the UI in gameworld
    public bool isUiActive;
    void OnMouseDown()
    {
        Debug.Log("Clicked");
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
