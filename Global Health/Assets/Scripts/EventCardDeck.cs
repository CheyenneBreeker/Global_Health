using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : MonoBehaviour
{
    public string _name;
    private string _description;
    private int _choices;
    GameObject _card;

    public EventCard(string name, string description, int choices)
    {
        _name = name;
        _description = description;
        _choices = choices;
    }
}

public class EventCardDeck : MonoBehaviour
{
    public List<EventCard> deck = new List<EventCard>();
    public List<EventCard> usedPile = new List<EventCard>();
    public int eventTriggers = 0;

    void Start()
    {
        EventCard event0 = new EventCard("event0", "A car accident caused...", 3);
        deck.Add(event0);

        // EventTrigger();
    }

    public void EventTrigger()
    {
        print("WORKED");
        int diceValue = Random.Range(1, 7);
        diceValue = diceValue + eventTriggers;

        if (diceValue >= 6)
        {
            TakeCard();
            eventTriggers = 0;
        }
        else
        {
            eventTriggers += 1;
        }
        return;
    }

    public EventCard TakeCard()
    {
        if (deck.Count == 0)
        {
            return null;
        }
        EventCard card = deck[0];
        deck.RemoveAt(0);
        usedPile.Add(card);

        print(card._name);
        return card;
    }
}
