using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEffects")]
public class EventCardEffects : ScriptableObject
{
    public string newDescription;

    public void CardEffect(string name, int choice)
    {
        switch (name)
        {
            case "event0":
                if (choice == 1)
                {
                    newDescription = "Correct response. Newborns are especially vulnerable and this girl would have died without immediate care.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2)
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    int randomPercentage = Random.Range(0, 101);

                    if (randomPercentage >= 50)
                    {
                        newDescription = "Newborns are especially vulnerable, so this girl had to be treated quickly. Because you send her to another city, her chances were 50/50. \n\nFortunately, in this scenario, the little girl did make it.";
                        GameWorld.Instance.substractIMU(800);
                    } else
                    {
                        newDescription = "Newborns are especially vulnerable, so this girl had to be treated quickly. Because you send her to another city, her chances were 50/50. \n\nUnfortunately, in this scenario, the little girl did not make it.";
                        GameWorld.Instance.substractIMU(800);
                        GameWorld.Instance.cities[1].UpdatePopulation(1, true);
                    }
                }
                if (choice == 3)
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    int randomPercentage = Random.Range(0, 101);

                    if (randomPercentage >= 80)
                    {
                        newDescription = "Newborns are especially vulnerable and health centers do not always have the correct methods to save them. In this scenario, the girl had 80% of dying by choosing this option. \n\nFortunately, the little girl did make it.";
                        GameWorld.Instance.substractIMU(400);
                    } else
                    {
                        newDescription = "Newborns are especially vulnerable and health centers do not always have the correct methods to save them. In this scenario, the girl had 80% of dying by choosing this option. \n\nUnfortunately, the little girl did not make it.";
                        GameWorld.Instance.substractIMU(400);
                        GameWorld.Instance.cities[1].UpdatePopulation(1, true);
                    }
                }
                if (choice == 4)
                {
                    newDescription = "Newborns are especially vulnerable and when situations like these occur, immediate professional help is needed. \n\nBy advising rest, the girl did not survive through the night.";
                    GameWorld.Instance.cities[1].UpdatePopulation(1, true);
                }
                break;
        }
    }
}
