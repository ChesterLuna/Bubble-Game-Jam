using UnityEngine;
using System.Collections.Generic;

public class DrinkOptionHub : MonoBehaviour {
    public static DrinkOptionHub instance; // singleton instance

    //-- Information hub
    public Dictionary<string, string> speciesPreferences = new Dictionary<string, string> {
        { "fairy", "fruit" },
        { "elf", "green" },
        { "orc", "milk" },
        { "dwarf", "oolong" },
        { "demon", "black" }
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
    }
}
