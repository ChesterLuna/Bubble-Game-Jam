using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    private TextMeshProUGUI textComponent = null;
    private Queue<string> dialogueQueue = new Queue<string>();
    [SerializeField] private GameObject nextButton;

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "";

        // Testing purposes, remove later
        for (int i = 0; i < 5; i++) {
            DisplayPreference("customer", "option1");
        }
        Debug.Log(dialogueQueue.Count);
    }

    private void Update() {
        if (dialogueQueue.Count == 0) {
            nextButton.SetActive(false);
        } else {
            nextButton.SetActive(true); 
        }
    }

    public void DisplayText() { // displays the text
        string text = dialogueQueue.Dequeue();
        textComponent.text += "\n" + text;
    }

    public void DisplayPreference(string name, string preference) { // generates one dialogue and displays it
        string[] options = DrinkOptionHub.instance.dialogues;
        string dial = options[Random.Range(0, options.Length)].Replace("_", "<color=#0088AA>" + preference + "</color>");
        dialogueQueue.Enqueue("<color=#11AA00>" + name + "</color>: " + dial);
    }

}