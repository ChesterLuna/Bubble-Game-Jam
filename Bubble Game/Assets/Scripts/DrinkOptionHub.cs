using UnityEngine;
using System.Collections.Generic;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;
using UnityEngine.XR;
using NUnit.Framework;
using System.Net.NetworkInformation;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.InputSystem.EnhancedTouch;

public class DrinkOptionHub : MonoBehaviour {
    public static DrinkOptionHub instance; // singleton instance
    [SerializeField] private GameObject guidebookPrefab;
    [SerializeField] private Transform guidebookParent;
    private GameObject guidebookInstance;

    //-- Information hub

    // Order matters
    public string[] toppings = new string[] {
        "boba",
        "flecks",
        "sugar",
        "truffle",
        "kumquat",
        "ambrosia",
        "clouds",
        "tears",
        "jelly",
        "beans"
    };

    public string[] properties = new string[] {
        "chewy",
        "luxe",
        "saccharine",
        "earthy",
        "citrusy",
        "refreshing",
        "fluffy",
        "intense",
        "novel",
        "calming"
    };

    public Dictionary<string, string> toppingsToProperties = new Dictionary<string, string>();
    public Dictionary<string, string> propertiesToToppings = new Dictionary<string, string>();

    public string[] bases = new string[] {
        "fruit",
        "green",
        "milk",
        "oolong",
        "black"
    };


    public Dictionary<string, string> speciesPreferences = new Dictionary<string, string> {
        { "fairy", "fruit" },
        { "elf", "green" },
        { "orc", "milk" },
        { "dwarf", "oolong" },
        { "demon", "black" }
    };

    public Dictionary<string, string> drinksToSpecies = new Dictionary<string, string> {
        { "fruit", "fairy"},
        { "green","elf"},
        { "milk","orc"},
        { "oolong","dwarf"},
        { "black", "demon"}
    };

    // dialogue options
    public string[] firstPreference = new string[] { // the _ will be replaced by the preference name
        "Something that is _ please!",
        "Today I think I'm in the mood for something _.",
        "Perhaps a drink that is _ would be best.",
        "Hmmm, _ sounds good I think...?",
        "I would quite like a tea that is _.",
        "I heard that a drink that is _ is quite good?",
        "Could I please have a tea that is _.",
        "The only thing that would get me going today is something that is _!",
        "Uh... _ please...",
        "I demand a drink that is _, quick quick!"
    };

    public string[] laterPreferences = new string[] {
        "Oh! And add something _ please!",
        "I think a drink that's _ as well sounds quite good, no?",
        "Perhaps add something _.",
        "I would like for you to add something that is _ if that's possible.",
        "I would also like it to be _ by the way.",
        "Sorry but could you also add something _?",
        "Actually, I also want the drink to be _ if you could add that please!",
        "_! If it's not too late, also add something for that!",
        "Umm... if it's not too much trouble please add something _...",
        "I insist that the drink is also _."
    };

    public string[] fillers = new string[] {
        "The weather's quite nice today, isn't it?! Perfect for a walk!",
        "You know, there's been some town drama stirring up... actually, forget I said anything.",
        "Work has been tough y'know, slaying monsters and all... Think I need a career change.",
        "You know that elf who lives down the block? I wanna send them a love letter but I'm nervous!",
        "I've heard some good things about this place so I'm here to try it out!",
        "So... what do humans do without tails or wings or super strength?",
        "Ridiculous... oh sorry, I'm not talking about you. I mean the voices in my head.",
        "The children are interested in your drinks but us adults need to make sure it's safe first!",
        "I'm sure your ingredients are locally sourced natural products, right?",
        "I'm a local food and drink critique for the town paper! I look forward to this experience.",
        "It's so nice that there's a tavern that doesn't just serve drafts of beer and ale.",
        "I think you're doing that wrong, I would know! I've poured water before!",
        "A group of fairies came into my shop and messed up my displays!",
        "I love dwarves, probably the best creatures around.",
        "Demons seem scary but they can actually be really nice!",
        "I wish more orcs would move into town, they just have such a unique charm...",
        "Have you considered adding phoenix feathers to your ingredients? You should!",
        "I'm not too sure about your human drink but as they say, don't knock it til you try it.",
        "I just went shopping the other day and now I'm fabulous!",
        "Could you hurry it up? The children are waiting for me."
    };

    private void Awake() { // making things singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void OnEnable() {

        // Populate dictionaries
        for (int i = 0; i < toppings.Length; i++)
        {
            toppingsToProperties.Add(toppings[i], properties[i]);
            propertiesToToppings.Add(properties[i], toppings[i]);
        }
    }

    public void ToggleGuidebook() {
        if (guidebookInstance == null) {
            guidebookInstance = Instantiate(guidebookPrefab, guidebookParent);
        } else {
            Destroy(guidebookInstance);
        }
    }

}
