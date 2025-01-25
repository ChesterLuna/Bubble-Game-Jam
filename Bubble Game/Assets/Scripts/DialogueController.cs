using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour {
    private string dialogueContent = "";
    private TextMeshProUGUI textComponent = null;
    [SerializeField] private TextAsset jsonFile;
    private List<string> prefereceOptions = new List<string> {"option 1", "option 2"};
    private DialogueOptions dialogueOptions;

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (jsonFile != null) {
            dialogueOptions = JsonUtility.FromJson<DialogueOptions>(jsonFile.text);
        }

        // Testing purposes, remove later
        for (int i = 0; i < 5; i++) {
            DisplayPreference("customer", "option1");
        }
    }

    private void DisplayText(string text) { // displays the text
        dialogueContent += "\n" + text;
        textComponent.text = dialogueContent;
    }

    public void DisplayPreference(string name, string preferences) { // generates one dialogue and displays it
        string[] options = dialogueOptions.getDialogue(preferences);
        string choice = "<color=green>" + name + ": </color>" + options[Random.Range(0, options.Length)].Replace("_", "<color=red>" + preferences + "</color>");
        DisplayText(choice);
    }
}

[System.Serializable]
public class DialogueOptions { // class to deserialize the json file
    public string[] option1;
    public string[] option2;

    public string[] getDialogue(string pref) { // gets the dialogue options
        switch (pref) {
            case "option1":
                return option1;
            case "option2":
                return option2;
            default:
                return null;
        }
    }
}