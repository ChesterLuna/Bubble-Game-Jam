using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderKeywordFilter.FilterAttribute;

public class DialogueController : MonoBehaviour {
    private TextMeshProUGUI textComponent = null;
    private Queue<string> dialogueQueue = new Queue<string>();
    [SerializeField] private GameObject nextButton;

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "";
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

    public void QueuePreferences(string teaBase, string[] toppings) {
        string name = "<color=#11AA00>" + DrinkOptionHub.instance.drinksToSpecies[teaBase] + "</color>: ";
        string[] options;
        string[] fillers = DrinkOptionHub.instance.fillers;

        dialogueQueue.Enqueue(name + fillers[Random.Range(0, fillers.Length)]); // add a filler at the start

        for (int i = 1; i < toppings.Length; i++) {
            if (i == 0) {
                options = DrinkOptionHub.instance.firstPreference;
            } else {
                options = DrinkOptionHub.instance.laterPreferences;
            }

            if (Random.Range(0, 10) == 0) {
                dialogueQueue.Enqueue(name + fillers[Random.Range(0, fillers.Length)]); // randomly add filler
            }

            string dial = options[Random.Range(0, options.Length)].Replace("_", "<color=#0088AA>" + DrinkOptionHub.instance.toppingsToProperties[toppings[i]] + "</color>");
            dialogueQueue.Enqueue(name + dial);
        }


    }
}