using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class GuidebookController : MonoBehaviour {

    private TextMeshProUGUI textComponent = null;
    private TextMeshProUGUI titleComponent = null;

    // <color=cyan></color>
    private string[] species = {"Orc", "Elf" };
    private Dictionary<string, string> descriptions = new Dictionary<string, string> {
        {"Orc", "Brawny and tough, you'll hear an Orc coming before you see them. As large and savage creatures, Orcs need a strong kick of caffeine to get them going for the day. As such, they find a strong affinity with the smooth, buttery and velvety <color=#0088AA>Milk Tea</color> base. Just be aware; you may find the toilet in a mess after they've had their share."},
        {"Elf", "Instantly recognizable from their pointy ears and lithe figures, Elves are known for their elegance and attunement with nature. Thus, there is no better match than delicate, slightly grassy flavours of a <color=#0088AA>Green Tea</color> base. As creatures that live for centuries, Elves have the highest standard so don't slack off around them!"},
    };

    private void Start() {
        titleComponent = transform.Find("GuideTitle").GetComponent<TextMeshProUGUI>();
        textComponent = transform.Find("GuideText").GetComponent<TextMeshProUGUI>();
        titleComponent.text = "Species: Orc";
        textComponent.text = descriptions["Orc"];
    }

    public void SwapDescription(string title) {
        if (species.Contains(title)) {
            titleComponent.text = "Species: " + title;
        } else {
            titleComponent.text = "Flavour: " + title;
        }

        textComponent.text = descriptions[title];
    }
}