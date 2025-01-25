using UnityEngine;
using System.Collections.Generic;

public class DrinkOptionHub : MonoBehaviour {
    public static DrinkOptionHub instance; // singleton instance

    //-- Information hub
    public Dictionary<string, string[]> dialogues = new Dictionary<string, string[]> {
        { "option1", new string[] {
            "I want _",
            "me want _",
            "_ please"} }
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
        Debug.Log(dialogues["option1"][0]);
    }
}
