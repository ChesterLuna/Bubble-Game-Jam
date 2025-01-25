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
        string[] diagList;
        if (DrinkOptionHub.instance.dialogues.TryGetValue(preference, out diagList)) {
            DisplayText("<color=green>" + name + "</color>: " + diagList[Random.Range(0, diagList.Length)].Replace("_", "<color=red>" + preference + "</color>"));
        }
    }
}