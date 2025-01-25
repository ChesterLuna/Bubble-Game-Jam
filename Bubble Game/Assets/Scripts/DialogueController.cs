using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour {
    private string dialogueContent = "";
    private TextMeshProUGUI textComponent = null;

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < 20; i++) {
            DisplayText("owo? testies? " + "<color=red>" + i.ToString() + "</color>");
        }
    }

    private void DisplayText(string text) {
        dialogueContent += "\n" + text;
        textComponent.text = dialogueContent;
    }
}