using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCheckBuildings : MonoBehaviour
{
    public Transform seaCityBuildings;
    public Transform riverCityBuildings;
    public Transform forestCityBuildings;
    public Transform mountainCityBuildings;

    public EventCardDescription choices;

    public void checkSeaCity(string country)
    {
        foreach(Transform building in seaCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && country == "Sea")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (country == "Mountain" || country == "River"))
            {
                choices.choice2.gameObject.SetActive(true);
            }

            if (building.name == "Flat")
            {

            }

            if (building.name == "School")
            {

            }
        }
    }

    public void checkRiverCity(string country)
    {
        foreach(Transform building in riverCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && country == "River")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (country == "Sea" || country == "Forest"))
            {
                choices.choice2.gameObject.SetActive(true);
            }

            if (building.name == "Flat")
            {

            }

            if (building.name == "School")
            {

            }
        }
    }

    public void checkForestCity(string country)
    {
        foreach(Transform building in forestCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && country == "Forest")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (country == "River" || country == "Mountain"))
            {
                choices.choice2.gameObject.SetActive(true);
            }

            if (building.name == "Flat")
            {

            }

            if (building.name == "School")
            {

            }
        }
    }

    public void checkMountainCity(string country)
    {
        foreach(Transform building in mountainCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && country == "Mountain")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (country == "Sea" || country == "Forest"))
            {
                choices.choice2.gameObject.SetActive(true);
            }

            if (building.name == "Flat")
            {

            }

            if (building.name == "School")
            {

            }
        }
    }

    public void checkNearbyCities(string country)
    {
        checkMountainCity(country);
        checkRiverCity(country);
        checkSeaCity(country);
        checkForestCity(country);
    }
}
