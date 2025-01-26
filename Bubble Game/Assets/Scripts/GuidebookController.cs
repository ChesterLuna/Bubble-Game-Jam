using UnityEngine;
using TMPro;

public class GuidebookController : MonoBehaviour {

    private TextMeshProUGUI textComponent = null;

    private void Start() {
        textComponent = transform.Find("GuideText").GetComponent<TextMeshProUGUI>();
    }
}