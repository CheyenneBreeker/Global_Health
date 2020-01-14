using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardDeck : MonoBehaviour
{
    public List<EventCard> deck = new List<EventCard>();
    public List<EventCard> usedPile = new List<EventCard>();
    public int eventTriggers = 0;
    public EventCardDescription newDescription;
    [HideInInspector]
    public bool eventActive = false;

    [SerializeField]
    private AudioClip eventSFX;

    void Start()
    {
        EventCard event0 = new EventCard("event0", "A new born girl in forest city refuses to drink and has a high fever. \n\n1. Send her to the nearest hospital. \n\n2. Send her to a health centre. \n\n3. Advise rest.", 3);
        deck.Add(event0);

        EventCard event1 = new EventCard("event1", "A 31-year-old man complains about an upset stomach. \n\n1. Send him to the nearest hospital. \n\n2. Send him to a health centre. \n\n3. Advise rest.", 3);
        deck.Add(event1);

        EventCard event2 = new EventCard("event2", "Near Sea city, because of a storm at sea, several fisherman have become injured. This includes 31 men and 7 women. Not everyone can be helped directly in Sea city. \n\n1. Treat the men first and send those that cannot be treated in Sea city to a different city. \n\n 2. Treat the women first and send those that cannot be treated in Sea city to a different city. \n\n 3. Treat the most injured people at Sea city, send the rest somewhere else.", 3);
        deck.Add(event2);

        EventCard event3 = new EventCard("event3", "Three miners have started to badly cough and experience tightness in the chest. They have difficulty with breating. \n\n1. Send them to a hospital. \n\n2. Do nothing.", 2);
        deck.Add(event3);

        EventCard event4 = new EventCard("event4", "Heavy rain caused the roads to be near inaccessible. The medicine that normally has to take this road, now cannot be delivered. \n\n1. If another route is available because of an earlier played card, choose this alternate route. \n\n2. Wait for the road to be repaired. \n\n3. Let the medicine carrier still take the almost inaccessible roads.", 3);
        deck.Add(event4);

        Shuffle();
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
            AudioManager.Instance.PlayEventSFX(eventSFX, 1);
            eventTriggers = 0;
            eventActive = true;
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
