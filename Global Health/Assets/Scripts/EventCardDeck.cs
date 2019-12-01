using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardDeck : MonoBehaviour
{
    public List<EventCard> deck = new List<EventCard>();
    public List<EventCard> usedPile = new List<EventCard>();
    public int eventTriggers = 0;
    public EventCardDescription newDescription;

    void Start()
    {
        EventCard event0 = new EventCard("event0", "A car accident caused...", 3);
        deck.Add(event0);

        EventCard event1 = new EventCard("event1", "A tsunami hit the town...", 4);
        deck.Add(event1);

        EventCard event2 = new EventCard("event2", "People have become dissatisfied...", 2);
        deck.Add(event2);

        Shuffle();
        TakeCard();
    }

    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            var temp = deck[i];
            Random.InitState(System.DateTime.Now.Millisecond);
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void EventTrigger()
    {
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

        newDescription.LoadCard(card);
        return card;
    }
}
