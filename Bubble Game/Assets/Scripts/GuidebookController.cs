using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GuidebookController : MonoBehaviour {

    private TextMeshProUGUI textComponent = null;
    private TextMeshProUGUI titleComponent = null;

    // <color=cyan></color>

    private Dictionary<string, string> descriptions = new Dictionary<string, string> {
        {"Orc", "Brawny and tough, you'll hear an Orc coming before you see them. As large and savage creatures, Orcs need a strong kick of caffeine to get them going for the day. As such, they find a strong affinity with the smooth, buttery and velvety <color=#0088AA>Milk Tea</color> base. Just be aware; you may find the toilet in a mess after they've had their share."},
    };

    private void Start() {
        titleComponent = transform.Find("GuideTitle").GetComponent<TextMeshProUGUI>();
        textComponent = transform.Find("GuideText").GetComponent<TextMeshProUGUI>();
        titleComponent.text = "Species: Orc";
        textComponent.text = descriptions["Orc"];
    }

}