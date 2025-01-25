using UnityEngine;
using TMPro;

public class ScoreContoller: MonoBehaviour {
    private TextMeshProUGUI textComponent = null;

    private void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        textComponent.text = ScoringSystem.instance.globalScore + "/" + ScoringSystem.instance.goalScore;
    }
}
