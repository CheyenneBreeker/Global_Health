using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : ScriptableObject
{
    public string _name;
    public string _description;
    public int _choices;
    GameObject _card;

    public EventCard(string name, string description, int choices)
    {
        _name = name;
        _description = description;
        _choices = choices;
    }
}
