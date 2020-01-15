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
    public EventCheckBuildings check;

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

        StartCoroutine(CardAppear());

        if (c._country == "Sea") { check.checkSeaCity("Sea"); check.checkNearbyCities("Sea"); }
        if (c._country == "River") { check.checkRiverCity("River"); check.checkNearbyCities("River"); }
        if (c._country == "Forest") { check.checkForestCity("Forest"); check.checkNearbyCities("Forest"); }
        if (c._country == "Mountain") { check.checkMountainCity("Mountain"); check.checkNearbyCities("Mountain"); }

        choice3.gameObject.SetActive(true);
        choice4.gameObject.SetActive(true);
    }

    public void OnButtonClick1()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
        effect.CardEffect(card._name, 1);
        loadNewDescription(card);
    }

    public void OnButtonClick2()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
        effect.CardEffect(card._name, 2);
        loadNewDescription(card);
    }

    public void OnButtonClick3()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
        effect.CardEffect(card._name, 3);
        loadNewDescription(card);
    }

    public void OnButtonClick4()
    {
        AudioManager.Instance.PlaySFX(buttonClicksSFX, 1);
        SetButtonsNonActive();
        effect.CardEffect(card._name, 4);
        loadNewDescription(card);
    }

    public void loadNewDescription(EventCard c)
    {
        _description.text = effect.newDescription;
    }

    public void SetButtonsNonActive()
    {
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        choice3.gameObject.SetActive(false);
        choice4.gameObject.SetActive(false);

        StartCoroutine(CardDisappear());
    }

    private IEnumerator CardAppear()
    {
        yield return new WaitForSeconds(1.5f);
        cardAni.Play("EventCard_Appear");
        yield return new WaitForSeconds(2.0f);
        cardAni.Play("EventCard_Idle2");
    }

    private IEnumerator CardDisappear()
    {
        yield return new WaitForSeconds(4f);
        cardAni.Play("EventCard_Disappear");
        yield return new WaitForSeconds(1.333f);
        cardAni.Play("EventCard_Idle");

        gameObject.SetActive(false);
        nextTurnButton.gameObject.SetActive(true);
        test.eventActive = false;
    }
}
