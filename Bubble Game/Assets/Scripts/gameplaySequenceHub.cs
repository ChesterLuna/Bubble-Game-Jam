using System.Collections.Generic;
using UnityEngine;

public class GameplaySequenceHub : MonoBehaviour {
    public static GameplaySequenceHub instance;
    public string playerName = "<color=#8800AA>You</color>";

    public Dictionary<int, string[]> dayScene = new Dictionary<int, string[]> {
        {1, new string[] {
            "Finally, a new untapped market... I've made it!",
            "The big city was too competitive, every human already knows the delicacy that is...",
            "BUBBLE TEA!",
            "But here in Magskjoldr, there's a ton of creatures who've never tasted the drink of the gods!",
            "Finally, I can make the gold I always deserved and rule a boba empire! Mwahah--",
            "Good thing I have my handy <color=#0088AA>Guidebook</color> if I get stuck making an order. Maybe I should look at it now...",
            "Oh look!, my first customer!"}
        },
        {2, new string[] {
            "I'm not getting as many customers as I was hoping...",
            "And if they don't like my drinks, they don't pay!",
            "If it keeps up, I'll be out of business in no time!",
            "I need to set a goal.",
            "Let's be reasonable: if I can earn <color=#E9B300>100 gold</color> by the end of the week, I'm sure I can convince the townspeople that The Boba Tavern should be here to stay!"}
        },
        {3, new string[] {
            "The third day and you know what they say, third time's the charm! I'm sure by the end of the day, I'll convince the creatures of this town that The Boba Tavern is here to stay!"}
        },
        {4, new string[] {
            "It's already day 4... I'm halfway through the week.",
            "I'm sure by now news has spread to the Fairies so I can add the Fruit Tea base for them.", 
            "And I've just received new stock!",
            "For customers who want something <color=#0088AA>Intense</color>, I can add <color=#0088AA>Dragon Tears</color> and to make the Bubble Tea <color=#0088AA>Fluffy</color>, I should add <color=#0088AA>Pixie Clouds</color>.",
            "Okay, let's do this!"}
        },
        {5, new string[] {
            "Alrighty, it's the fifth day! I feel pumped with the dwarf tavern owner's talk and he's right, I gotta keep going! Let's make today a good one!"}
        },
        {6, new string[] {
            "The sixth day... just one more day after this. I gotta keep up the momentum and make sure I finish strong!",
            "Demons might start coming by so I should serve the Black Tea base for them.", 
            "The last stock for my toppings have also arrive now.",
            "For customers who want something <color=#0088AA>Novel</color>, I need to add the <color=#0088AA>Sunbeam Jelly</color> topping and to create a <color=#0088AA>Calming</color> effect, I would need some <color=#0088AA>Magic Beans</color>.",
            "Got it, I can do it!"}
        },
        {7, new string[] {
            "The last day! I've worked so hard this week and have served so many customers... now it's time to use everything I've learned for this last push!",
            "I need to reach <color=#E9B300>100 gold</color>"}
        }
    };

    private void Awake() { // making things singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this);
        }
    }
}
