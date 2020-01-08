using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstruction : MonoBehaviour
{
    public int Turncountdown;
    public bool CountdownStarted = false;


    public void BuildingCountdown()
    {
        if (CountdownStarted)
        {
            Turncountdown -= 1;

            if(Turncountdown == 0)
            {
                gameObject.SetActive(true);
            }
        }
    }



}
