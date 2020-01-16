using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : ScriptableObject
{
    public string _name;
    public string _description;
    public string _country;
    GameObject _card;

    public EventCard(string name, string description, string country)
    {
        _name = name;
        _description = description;
        _country = country;
    }
}
