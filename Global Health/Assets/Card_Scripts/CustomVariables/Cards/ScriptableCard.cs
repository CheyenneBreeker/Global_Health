using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "New Playing Card")]
public class ScriptableCard : ScriptableObject
{
        public string cardName;
        public float cardCost;
        [Multiline]
        public string cardFlavorText;




    public string CardEffect;
    //example: "ChangePopulation"
    public int cardValue;
    public bool NegativeValue;

    [Header("0 for City 1, 1 for City 2, 2 for City 3, 3 for city 4")]
    public int affectedCity;

    [Header("Such as TownHall")]
    public string AddedBuilding;


}

