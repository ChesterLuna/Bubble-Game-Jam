using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour {
    private string dialogueContent = "";
    private TextMeshProUGUI textComponent = null;

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();

        // Testing purposes, remove later
        for (int i = 0; i < 5; i++) {
            DisplayPreference("customer", "option1");
        }
    }

    private void DisplayText(string text) { // displays the text
        dialogueContent += "\n" + text;
        textComponent.text = dialogueContent;
    }

    public void DisplayPreference(string name, string preference) { // generates one dialogue and displays it
        string[] options = DrinkOptionHub.instance.dialogues;
        string dial = options[Random.Range(0, options.Length)].Replace("_", "<color=#0088AA>" + preference + "</color>");
        DisplayText("<color=#11AA00>" + name + "</color>: " + dial);
    }
}