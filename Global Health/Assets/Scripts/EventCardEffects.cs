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

            case "event1":
                if (choice == 1)
                {
                    newDescription = "Correct response. This boy got malaria from playing in the forest, through a mosquito bite. Because of the quick care, the boy will survive.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2)
                {
                    newDescription = "Still a good response, but not the best one. This boy got malaria from playing in the forest, through a mosquito bite. Because of the delayed care, the boy will have to live with respiratory distress for the rest of his life.";
                    GameWorld.Instance.substractIMU(800);
                }
                if (choice == 3)
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    int randomPercentage = Random.Range(0, 101);

                    if (randomPercentage >= 70)
                    {
                        newDescription = "This boy got malaria from playing in the forest, through a mosquito bite. Because a health center doesn't have the best options available, the boy has 70% chance of dying. \nFortunately, in this scenario, the boy did make it. He does have to live with respiratory distress the rest of his life.";
                    } else
                    {
                        newDescription = "This boy got malaria from playing in the forest, through a mosquito bite. Because a health center doesn't have the best options available, the boy has 70% chance of dying. \nUnfortunately, in this scenario, the boy did not make it.";
                        GameWorld.Instance.cities[3].UpdatePopulation(1, true);
                    }
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "This boy got malaria from playing in the forest, through a mosquito bite. Just advising rest did not help, the boy did not survive.";
                    GameWorld.Instance.cities[3].UpdatePopulation(1, true);
                }
                if (choice == 5) newDescription = "By building a school in this city (Forest City), you have prevented a boy from getting malaria. Well done.";
                
                break;

            case "event2":
                if (choice == 1 || choice == 2)
                {
                    newDescription = "The man was just having some gas issues. The hospital isn't happy with unnecessary extra work and charges you extra.";
                    GameWorld.Instance.substractIMU(1500);
                }
                if (choice == 3)
                {
                    newDescription = "The man was just having some gas issues. The health center helped him just fine.";
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "The man was just having some gas issues. After having rested a bit, and having gone to the toilet, he was fine";
                }

                break;

            case "event3":
                if (choice == 1)
                {
                    newDescription = "Wise choice. The man was having a heart attack, and would not have survived without immediate special care.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2)
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    int randomPercentage = Random.Range(0, 101);

                    if (randomPercentage >= 90)
                    {
                        newDescription = "The man was having a heart attack, and choosing for the most time consuming option won't always end well. Particularly in this case, the man had 90% chance of dead with this option. \n\nFortunately, the man surpassed all odds and lived to tell the tale.";                       
                    }
                    else
                    {
                        newDescription = "The man was having a heart attack, and choosing for the most time consuming option won't always end well. Particularly in this case, the man had 90% chance of dead with this option. \n\nUnfortunately, the man died on the way there.";
                        GameWorld.Instance.cities[2].UpdatePopulation(1, true);
                    }
                    GameWorld.Instance.substractIMU(800);
                }
                if (choice == 3)
                {
                    newDescription = "The man was suffering from a heart attack and the health center unfortunately couldn't save him in time.";
                    GameWorld.Instance.substractIMU(400);
                    GameWorld.Instance.cities[2].UpdatePopulation(1, true);
                }
                if (choice == 4)
                {
                    newDescription = "The man was suffering from a heart attack and did not survive the night.";
                    GameWorld.Instance.cities[2].UpdatePopulation(1, true);
                }
                break;

            case "event4":
                if (choice == 1)
                {
                    newDescription = "Wise choice. The woman was having a heart attack, and would not have survived without immediate special care.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2)
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    int randomPercentage = Random.Range(0, 101);

                    if (randomPercentage >= 90)
                    {
                        newDescription = "The woman was having a heart attack, and choosing for the most time consuming option won't always end well. Particularly in this case, the woman had 90% chance of dead with this option. \n\nFortunately, the man surpassed all odds and lived to tell the tale.";
                    }
                    else
                    {
                        newDescription = "The woman was having a heart attack, and choosing for the most time consuming option won't always end well. Particularly in this case, the woman had 90% chance of dead with this option. \n\nUnfortunately, the man died on the way there.";
                        GameWorld.Instance.cities[3].UpdatePopulation(1, true);
                    }
                    GameWorld.Instance.substractIMU(800);
                }
                if (choice == 3)
                {
                    newDescription = "The woman was suffering from a heart attack and the health center unfortunately couldn't save her in time.";
                    GameWorld.Instance.substractIMU(400);
                    GameWorld.Instance.cities[3].UpdatePopulation(1, true);
                }
                if (choice == 4)
                {
                    newDescription = "The woman was suffering from a heart attack and did not survive the night.";
                    GameWorld.Instance.cities[3].UpdatePopulation(1, true);
                }
                break;

            case "event5":
                if (choice == 1 || choice == 2)
                {
                    newDescription = "Thankfully the blood from his head turned out to be just a shallow cut, but this could have been far worse. The hospital patched him up and he will be fine.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 3)
                {
                    newDescription = "Even though the head wound turned out to be just a shallow cut, how is the health center supposed to treat his leg? They don't have the means, except for some quick fixes. The man will be send through to the hospital, and will have to pay both instances.";
                    GameWorld.Instance.substractIMU(1800);
                }
                if (choice == 4)
                {
                    newDescription = "Are you sure that someone with a visibly broken leg and a head wound, however small, should just be adviced rest? Don't think so. The man files a complaint and they charge you 2500 IMU for the oversight.";
                    GameWorld.Instance.substractIMU(2500);
                }
                break;

            case "event6":
                if (choice == 1)
                {
                    newDescription = "The woman turned out to be suffering from a severe concussion, so it's a good thing you chose to send her to the hospital. She will live.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2)
                {
                    newDescription = "The woman turned out to be suffering from a severe concussion. Thankfully the doctors caught it in time, but because the care wasn't immediate, she will have to be careful for the rest of her life.";
                    GameWorld.Instance.substractIMU(800);
                }
                if (choice == 3)
                {
                    newDescription = "The health center spotted she has a concussion, but couldn't determine how severe. She will forever have memory problems and has a higher chance of falling into depression. Apart from that, they didn't have the means to correct her foot beside a quick fix. She needed to go to the hospital anyway and pay double.";
                    GameWorld.Instance.substractIMU(1400);
                }
                if (choice == 4)
                {
                    newDescription = "Because of her foot and the severe concussion that she couldn't have known about without health care, she became dizzy at the top of the stairs and fell down. She died instantly.";
                    GameWorld.Instance.cities[2].UpdatePopulation(1, true);
                }
                break;

            case "event7":
                if (choice == 1)
                {
                    newDescription = "Both the woman and the baby would not have survived without immediate care. It turns out that the woman was going into preterm labor.";
                    GameWorld.Instance.substractIMU(1000);
                    GameWorld.Instance.cities[0].UpdatePopulation(1, false);
                }
                if (choice == 2)
                {
                    newDescription = "The woman was going into preterm labor. While the mother has survived, the baby unfortunately did not make it.";
                    GameWorld.Instance.substractIMU(800);
                }
                if (choice == 3)
                {
                    newDescription = "The woman was going into preterm labor. The health center has managed to rescue the baby, but unfortunately at the cost of the mother.";
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "The woman was going into preterm labor. Because you send them home, more complications arose and both the mother and the baby did not survive.";
                    GameWorld.Instance.cities[0].UpdatePopulation(1, true);
                }
                break;

            case "event8":
                if (choice == 1 || choice == 2)
                {
                    newDescription = "A bit unnecessary, but it is a good thing that it has been caught this early on. The man is in the earliest stages of dementia.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 3)
                {
                    newDescription = "The health center managed to conclude that he is in the earliest stages of dementia. Good thing that it has been caught this early, and also that he didn't immediately go to the hospital, which would have been overkill";
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "Since it is only the earliest stages of dementia, he will indeed be fine for now. However, if it had have been way worse, this would have been a bad option.";
                }
                break;

            case "event9":
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    newDescription = "Unfortunately this woman has HIV, which isn't curable. This could have been prevented with a better economy and schooling.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 4)
                {
                    newDescription = "The woman has HIV, but she won't know this now. She will continue to spread it.";
                }
                if (choice == 5)
                {
                    newDescription = "Because of the better economy and schooling, this event was prevented, well done. A 21-year-old woman would have gotten HIV.";
                }
                break;

            case "event10":
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    newDescription = "Unfortunately this man has HIV, which isn't curable. This could have been prevented with a better economy and schooling.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 4)
                {
                    newDescription = "The man has HIV, but he won't know this now. he will continue to spread it.";
                }
                if (choice == 5)
                {
                    newDescription = "Because of the better economy and schooling, this event was prevented, well done. A 24-year-old man would have gotten HIV.";
                }
                break;

            case "event11":
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    newDescription = "Good call. The woman suffers from anemia, which she wouldn't have recovered from on her own. With professional help though, she will be just fine.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 4)
                {
                    newDescription = "This woman suffered from anemia. This does not become better on it's own. After a while, she started getting dizzy spells. One of those dizzy spells hit her at the wrong time, causing her to have an accident. She died shortly after.";
                    GameWorld.Instance.cities[1].UpdatePopulation(1, true);
                }
                break;

            case "event12":
                if (choice == 1 || choice == 2)
                {
                    newDescription = "The man just needed some glasses. The hospital is annoyed and charges extra.";
                    GameWorld.Instance.substractIMU(1800);
                }
                if (choice == 3)
                {
                    newDescription = "The man just needed some glasses. The health center was happy to direct him to a place where he could get an eye test.";
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "The man was just in need of some glasses. Even without them, and just getting some rest, he would have lived just fine. Even if his eyesight would slowly deteriorate further.";
                }
                break;

            case "event13":
                if (choice == 1)
                {
                    newDescription = "With the immediate care from the hospital, the man somehow managed to pull through. Any other option would have killed him.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2 || choice == 3)
                {
                    newDescription = "Without the immediate care from a hospital, the man died.";
                    GameWorld.Instance.substractIMU(800);
                    GameWorld.Instance.cities[0].UpdatePopulation(1, true);
                }
                if (choice == 4)
                {
                    newDescription = "The man could not survive with his intestines outside of his body. He died shortly after the fight.";
                    GameWorld.Instance.cities[0].UpdatePopulation(1, true);
                }
                break;

            case "event14":
                if (choice == 1)
                {
                    newDescription = "The brain can only survive so long without oxygen. Because of the immediate care of the hospital, they managed to save him without any brain damage.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 2)
                {
                    newDescription = "The brain can only survive so long without oxygen. Because the trip to the nearby town took way too long, the boy died on the way there.";
                    GameWorld.Instance.substractIMU(800);
                    GameWorld.Instance.cities[0].UpdatePopulation(1, true);
                }
                if (choice == 3)
                {
                    newDescription = "The brain can only survive so long without oxygen. Because of the immediate care of the health center, they managed to save the boy.";
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "The brain can only survive so long without oxygen. The boy passed away.";
                    GameWorld.Instance.cities[0].UpdatePopulation(1, true);
                }
                break;

            case "event15":
                if (choice == 1 || choice == 2)
                {
                    newDescription = "The girl only had some scrapes on her knees. Sending her to a hospital was overkill.";
                    GameWorld.Instance.substractIMU(1500);
                }
                if (choice == 3)
                {
                    newDescription = "The girl only had some scrapes on her knees. The health center disinfected the wound and she was good to go.";
                    GameWorld.Instance.substractIMU(400);
                }
                if (choice == 4)
                {
                    newDescription = "The girl went home. Her mom gave her a band-aid for the scrapes. She will be fine.";
                }
                break;

            case "event16":
                if (choice == 1 || choice == 2)
                {
                    newDescription = "The miners had inhaled asbestos. Without immediate care of a hospital, it could've gone from bad to worse, with the miners getting cancer.";
                    GameWorld.Instance.substractIMU(1000);
                }
                if (choice == 3)
                {
                    newDescription = "The miners had inhaled asbestos. The health center immediately send them to the nearest hospital, because they do not have the equipment to handle this.";
                    GameWorld.Instance.substractIMU(1800);
                }
                if (choice == 4)
                {
                    newDescription = "The miners had inhaled asbestos. Because they didn't see a doctor, it developed into cancer. They all died sometime after.";
                    GameWorld.Instance.cities[2].UpdatePopulation(3, true);
                }
                break;
        }
    }
}
