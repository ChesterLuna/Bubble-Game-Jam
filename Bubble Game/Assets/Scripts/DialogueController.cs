using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using static UnityEditor.ShaderKeywordFilter.FilterAttribute;

public class DialogueController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI textComponent = null;
    [SerializeField] private Queue<string> dialogueQueue = new Queue<string>();
    [SerializeField] private GameObject nextButton;
    
    [SerializeField] private bool displayingIntro = true;
    [SerializeField] GameObject levelManager;

    [SerializeField] private bool displayingOutro;
    [SerializeField] private List<GameObject> NPCsToSpawn;
    [SerializeField] private List<int> dialogueToSpawnNPC;
    [SerializeField] private List<int> soundToplay;
    private int outroCounter;

    private void Awake() {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "";
        levelManager = GameObject.FindGameObjectWithTag("GameController");

    }

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
        // textComponent.text = "";
        levelManager = GameObject.FindGameObjectWithTag("GameController");

    }

    private void Update() {
        if (dialogueQueue.Count == 0) {
            nextButton.SetActive(false);
        } else {
            nextButton.SetActive(true); 
        }
    }

    public void DisplayText() { // displays the text
        if(displayingOutro)
        {
            if(dialogueToSpawnNPC.Count != 0)
            {
                if (dialogueToSpawnNPC[0] == outroCounter)
                {
                    NPCsToSpawn[0].gameObject.SetActive(true);
                    dialogueToSpawnNPC.RemoveAt(0);
                    NPCsToSpawn.RemoveAt(0);
                }
            }
            if (soundToplay.Count != 0)
            {
                if (soundToplay[0] == outroCounter)
                {
                    // Play sound clip
                }
            }
            outroCounter++;
            if(dialogueQueue.Peek() == "ENDSCENE")
            {
                ScenesManager.instance.ChangeDay();
            }
        }
        if (displayingIntro && dialogueQueue.Peek() == "ENDINTRO")
        {
            displayingIntro = false;
            ClearDialogue();
            levelManager.GetComponent<CustomerSpawner>().SpawnCustomer(ScenesManager.instance.currentDifficulty);
            levelManager.GetComponent<Timer>().StartTimer();
            DisplayText();
            return;
        }
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
            if (i == 1) {
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

    public void QueueSequenceDialogue(int dayNum) {
        if (GameplaySequenceHub.instance.dayScene.ContainsKey(dayNum)) {
            foreach (string dialogue in GameplaySequenceHub.instance.dayScene[dayNum]) {
                dialogueQueue.Enqueue(GameplaySequenceHub.instance.playerName + dialogue);
            }
        } else {
            dialogueQueue.Enqueue(GameplaySequenceHub.instance.playerName + "Day " + dayNum.ToString() + ". Time to get this bread.");
        }
        dialogueQueue.Enqueue("ENDINTRO");
        DisplayText();

    }

    public void QueueOutroDialogue(string key)
    {
        if (GameplaySequenceHub.instance.outroScene.ContainsKey(key))
        {
            foreach (string dialogue in GameplaySequenceHub.instance.outroScene[key])
            {
                dialogueQueue.Enqueue(dialogue);
            }
        }
        else
        {
            dialogueQueue.Enqueue(GameplaySequenceHub.instance.playerName + "Day " + key + ". Time to get this bread.");
        }
    }

    public void DisplayOutro()
    {
        displayingOutro = true;

        string dayString = ScenesManager.instance.currentDay.ToString();

        if (ScoringSystem.instance.PassedDaily())
        {
            dayString += "S";
        }
        else
        {
            dayString += "F";
        }

        QueueOutroDialogue(dayString);

        dialogueQueue.Enqueue("ENDSCENE");

        DisplayText();
    }
}