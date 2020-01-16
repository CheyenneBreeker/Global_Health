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
        EventCard event0 = new EventCard("event0", "A newborn girl in Sea City refuses to drink, and has a high fever.  \n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Sea");
        deck.Add(event0);

        EventCard event1 = new EventCard("event1", "In Forest City, an eight-year-old boy complains about a headache, vomiting and a fever. \n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Forest");
        deck.Add(event1);

        EventCard event2 = new EventCard("event2", "In River City, a 31-year-old man complains about an upset stomach. \n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "River");
        deck.Add(event2);

        EventCard event3 = new EventCard("event3", "In Mountain City, a 42-year-old man complains about pain in his left arm, shortness of breath and some chest pressure.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Mountain");
        deck.Add(event3);

        EventCard event4 = new EventCard("event4", "In Forest City, a 51-year-old woman complains about pain in her neck and head, and is slightly short of breath.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Forest");
        deck.Add(event4);

        EventCard event5 = new EventCard("event5", "A man (28-years-old) was trying to transport his goods from River City to Sea City. He got into a car accident, with the only visible wounds being; His right leg is in a weird angle, some glass is stuck in his hands from protecting his face, and some blood is trickling down the side of his head.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "River");
        deck.Add(event5);

        EventCard event6 = new EventCard("event6", "A woman (31-years-old) was trying to get to Mountain City when she got into a car accident. The only visible injuries are; A weirdly angled foot, scratches alongside her arms, and she is unconscious.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Mountain");
        deck.Add(event6);

        EventCard event7 = new EventCard("event7", "A 24-year-old woman in Forest City is complaining about cramps from her stomach. She is 34 weeks pregnant.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Forest");
        deck.Add(event7);

        EventCard event8 = new EventCard("event8", "A 68-year-old man in Sea City complains about becoming older and not being able to remember certain short-term events\n\n1.Send him / her to the hospital in town. \n\n2.Send him / her to the hospital in the nearby town. \n\n3.Send him / her to the health center in town. \n\n4.Advise rest.", "Sea");
        deck.Add(event8);

        EventCard event9 = new EventCard("event9", "In Mountain City a 21-year-old woman complains about a sore throat, a headache and sores on her genitalia.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Mountain");
        deck.Add(event9);

        EventCard event10 = new EventCard("event10", "In Forest City a 24-year-old man complains about a fever and diarrhea. He is also constantly tired.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Forest");
        deck.Add(event10);

        EventCard event11 = new EventCard("event11", "In Sea City, a 66-year-old woman is constantly tired and weak feeling. She also just cannot seem to keep her hands warm.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Sea");
        deck.Add(event11);

        EventCard event12 = new EventCard("event12", "In Mountain City, a 34-year-old man complains about headaches and eye strain.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Mountain");
        deck.Add(event12);

        EventCard event13 = new EventCard("event13", "In River City, two adult males (age 21 and 23) got into a fist fight, which later turned into a knife fight. The 21-year-old got away relatively unscathed, but the 23-year-old has a big slash across his stomach. He is visibly holding his own intestines inside of himself. \n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "River");
        deck.Add(event13);

        EventCard event14 = new EventCard("event14", "In River City, a 10-year-old boy was playing along the riverside, when he fell in. Nearby citizens managed to get him out, but he isn't breathing.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Forest");
        deck.Add(event14);

        EventCard event15 = new EventCard("event15", "A 9-year-old girl in Sea City was playing with her newly acquired bike, when she tripped over a rock. The only visible wounds are some scrapes on her knees.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Sea");
        deck.Add(event15);

        EventCard event16 = new EventCard("event16", "Three miners near Mountain City have started to badly cough and experience tightness in the chest. They have difficulty with breathing.\n\n1. Send him/her to the hospital in town. \n\n2. Send him/her to the hospital in the nearby town. \n\n3. Send him/her to the health center in town. \n\n4. Advise rest.", "Mountain");
        deck.Add(event16);

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
