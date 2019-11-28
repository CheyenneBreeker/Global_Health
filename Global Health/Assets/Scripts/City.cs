using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public int currentPopulation;

    private void SendPopulation()
    {
        GameWorld.Instance.NewPopulation(currentPopulation);
    }
}
