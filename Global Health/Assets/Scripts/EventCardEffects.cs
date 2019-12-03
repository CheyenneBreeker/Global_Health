using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEffects")]
public class EventCardEffects : ScriptableObject
{
    public void CardEffect(string name)
    {
        switch (name)
        {
            case "event0":
                GameWorld.Instance.substractIMU(5);
                break;
        }
    }
}
