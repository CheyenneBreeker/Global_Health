using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventCardDescription : MonoBehaviour
{
    public Text _description;
    public EventCard card;

    public Button choice1;
    public Button choice2;
    public Button choice3;
    public Button choice4;

    public EventCardDeck test;
    public EventCardEffects effect;

    public void Start()
    {
        gameObject.SetActive(false);

        choice1.onClick.AddListener(OnButtonClick1);
        choice2.onClick.AddListener(OnButtonClick2);
        choice3.onClick.AddListener(OnButtonClick3);
        choice4.onClick.AddListener(OnButtonClick4);
    }

    public void LoadCard(EventCard c)
    {
        if (c == null) return;

        print(c._description);
        card = c;
        _description.text = c._description;

        gameObject.SetActive(true);

        for(int i = 0; i < c._choices; i++)
        {
            if (i == 0) choice1.gameObject.SetActive(true);
            if (i == 1) choice2.gameObject.SetActive(true);
            if (i == 2) choice3.gameObject.SetActive(true);           
            if (i == 3) choice4.gameObject.SetActive(true);
        }
    }

    public void OnButtonClick1()
    {
        SetButtonsNonActive();
    }

    public void OnButtonClick2()
    {
        SetButtonsNonActive();
        effect.CardEffect(card._name);
    }

    public void OnButtonClick3()
    {
        SetButtonsNonActive();
    }

    public void OnButtonClick4()
    {
        SetButtonsNonActive();
    }

    public void SetButtonsNonActive()
    {
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        choice3.gameObject.SetActive(false);
        choice4.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
