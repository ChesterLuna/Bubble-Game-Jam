using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using static UnityEditor.ShaderKeywordFilter.FilterAttribute;

public class DialogueController : MonoBehaviour {
    private TextMeshProUGUI textComponent = null;
    [SerializeField] private Queue<string> dialogueQueue = new Queue<string>();
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
        string creatureName = DrinkOptionHub.instance.drinksToSpecies[teaBase];
        creatureName = creatureName[0].ToString().ToUpper() + creatureName.Substring(1);
        string name = "<color=#11AA00>" + creatureName + "</color>: ";
        string[] options;
        string[] fillers = DrinkOptionHub.instance.fillers;

        for (int i = 1; i < toppings.Length; i++) {
            if (i == 0) {
                options = DrinkOptionHub.instance.firstPreference;
            } else {
                options = DrinkOptionHub.instance.laterPreferences;
            }


            string chosenDialogue = options[Random.Range(0, options.Length)];

            string dial = ReplacePreference(chosenDialogue, toppings[i]);
            dialogueQueue.Enqueue(name + dial);
            if (Random.Range(0, 10) == 0)
            {
                dialogueQueue.Enqueue(name + fillers[Random.Range(0, fillers.Length)]); // randomly add filler
            }
        }

    }

    public bool IsTalking()
    {
        return dialogueQueue.Count > 0;
    }


    private string ReplacePreference(string dialogue, string topping)
    {
        string preference = DrinkOptionHub.instance.toppingsToProperties[topping];
        return dialogue.Replace("_", "<color=#0088AA>" + preference + "</color>");
    }

    public void ClearDialogue()
    {
        dialogueQueue.Clear();
        textComponent.text = "";

    }
}