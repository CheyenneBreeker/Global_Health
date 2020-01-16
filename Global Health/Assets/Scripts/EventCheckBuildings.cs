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

    public void checkSeaCity(string name)
    {
        foreach(Transform building in seaCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && name == "Sea")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (name == "Mountain" || name == "River"))
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

    public void checkRiverCity(string name)
    {
        foreach(Transform building in riverCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && name == "River")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (name == "Sea" || name == "Forest"))
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

    public void checkForestCity(string name)
    {
        foreach(Transform building in forestCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && name == "Forest")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (name == "River" || name == "Mountain"))
            {
                choices.choice2.gameObject.SetActive(true);
            }

            if (building.name == "Flat" && building.gameObject.activeSelf == true && name == "event10")
            {
                if (building.name == "School" && building.gameObject.activeSelf == true && name == "event10")
                {
                    choices.eventAvoided();
                }
            }

            if (building.name == "School" && building.gameObject.activeSelf == true && name == "event1")
            {
                choices.eventAvoided();
            }
        }
    }

    public void checkMountainCity(string name)
    {
        foreach(Transform building in mountainCityBuildings)
        {
            if (building.name == "Hospital" && building.gameObject.activeSelf == true && name == "Mountain")
            {
                choices.choice1.gameObject.SetActive(true);
            }

            if (building.name == "Hospital" && building.gameObject.activeSelf == true && (name == "Sea" || name == "Forest"))
            {
                choices.choice2.gameObject.SetActive(true);
            }

            if (building.name == "Flat" && building.gameObject.activeSelf == true && name == "event9")
            {
                if (building.name == "School" && building.gameObject.activeSelf == true && name == "event9")
                {
                    choices.eventAvoided();
                }
            }
        }
    }

    public void checkNearbyCities(string name)
    {
        checkMountainCity(name);
        checkRiverCity(name);
        checkSeaCity(name);
        checkForestCity(name);
    }
}
