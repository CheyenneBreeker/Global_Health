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

    public Animator cardAni;
    public Button nextTurnButton;

    [SerializeField]
    private AudioClip buttonClicksSFX;

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

        StartCoroutine(CardAppear(c));
    }

    public void OnButtonClick1()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
    }

    public void OnButtonClick2()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
        effect.CardEffect(card._name);
    }

    public void OnButtonClick3()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
    }

    public void OnButtonClick4()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
    }

    public void SetButtonsNonActive()
    {
        StartCoroutine(CardDisappear());
    }

    private IEnumerator CardAppear(EventCard c)
    {
        yield return new WaitForSeconds(1.5f);
        cardAni.Play("EventCard_Appear");
        yield return new WaitForSeconds(2.0f);
        cardAni.Play("EventCard_Idle2");

        for (int i = 0; i < c._choices; i++)
        {
            if (i == 0) choice1.gameObject.SetActive(true);
            if (i == 1) choice2.gameObject.SetActive(true);
            if (i == 2) choice3.gameObject.SetActive(true);
            if (i == 3) choice4.gameObject.SetActive(true);
        }
    }

    private IEnumerator CardDisappear()
    {
        cardAni.Play("EventCard_Disappear");
        yield return new WaitForSeconds(1.333f);
        cardAni.Play("EventCard_Idle");
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        choice3.gameObject.SetActive(false);
        choice4.gameObject.SetActive(false);
        gameObject.SetActive(false);

        nextTurnButton.gameObject.SetActive(true);
        test.eventActive = false;
    }
}
