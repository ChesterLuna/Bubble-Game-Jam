using UnityEngine;
using System.Collections.Generic;

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


    public Dictionary<string, string[]> dialogues = new Dictionary<string, string[]> {
        { "option1", new string[] {
            "I want option1",
            "me want option1",
            "option1 please"} }
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
