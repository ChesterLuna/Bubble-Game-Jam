using UnityEngine;
using System.Collections.Generic;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;
using UnityEngine.XR;

public class DrinkOptionHub : MonoBehaviour {
    public static DrinkOptionHub instance; // singleton instance

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
    public string[] dialogues = new string[] {
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

    private void Awake() { // making things singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void Start() {

        // Populate dictionaries
        for (int i = 0; i < toppings.Length; i++)
        {
            toppingsToProperties.Add(toppings[i], properties[i]);
            propertiesToToppings.Add(properties[i], toppings[i]);
        }
    }
}
