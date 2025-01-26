using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class GuidebookController : MonoBehaviour {

    private TextMeshProUGUI textComponent = null;
    private TextMeshProUGUI titleComponent = null;

    // <color=cyan></color>
    private string[] species = {"Orc", "Elf", "Dwarf", "Fairy", "Demon" };
    private Dictionary<string, string> descriptions = new Dictionary<string, string> {
        {"Orc", "Brawny and tough, you'll hear an Orc coming before you see them. As large and savage creatures, Orcs need a strong kick of caffeine to get them going for the day. As such, they find a strong affinity with the smooth, buttery and velvety <color=#0088AA>Milk Tea</color> base. Just be aware; you may find the toilet in a mess after they've had their share."},
        {"Elf", "Instantly recognizable from their pointy ears and lithe figures, Elves are known for their elegance and attunement with nature. Thus, there is no better match than delicate, slightly grassy flavours of a <color=#0088AA>Green Tea</color> base. As creatures that live for centuries, Elves have the highest standard so don't slack off around them!"},
        {"Dwarf", "Dwarves are short, subterranean dwellers who are known for their strong work ethic. With their stout statures and industrious nature, there's no better suited tea than the substantial and toasty <color=#0088AA>Oolong Tea</color> Base. Much like the warmth of this roasted tea, Dwarves are warm-hearted with much mutual respect for others' diligence."},
        {"Fairy", "The flittering Fairies are mischievous and delightful, energetically flying around with their brilliant wings. Being such dynamic creatures, Fairies prefer the flavour profile of the pleasant <color=#0088AA>Fruit Tea</color> base. Just be a bit careful of the sugar rush they get; with such small bodies, the bubble tea may get them chaotically out of control!"},
        {"Demon", "Demons are terrifying, horned creatures with a palpable bloodlust that will surely intimidate you. Luckily, a great substitution for the taste of blood is the rich and malty <color=#0088AA>Black Tea</color> base. However, once their natural instincts are sated, Demons can actually be quite lovely conversationalists and generous customers."},

        {"Chewy", "For creatures seeking something Chewy, add <color=#0088AA>Golden Boba</color>. It is one of the most classic and popular toppings with an interesting texture that will delight any creature."},
        {"Luxe", "For creatures seeking something Luxe, add <color=#0088AA>Moonshine Flecks</color>. This topping has an expensive and high-end quality that will melt in the creature's mouth."},
        {"Saccharine", "For creatures seeking something Saccharine, add <color=#0088AA>Rainbow Sugar</color>. When the tea base doesn't suffice, this topping will have rainbows blasting off the creature's tongue."},
        {"Earthy", "For creatures seeking something Earthy, add <color=#0088AA>Hearty Truffle</color></color>. This luminous mushroom invigorates the creature with its gritty, dirt-like aroma."},
        {"Citrusy", "For creatures seeking something Citrusy, add <color=#0088AA>Enchanted Kumquat</color>. The tangy and tart flavour profile will deliver a zing to the creature's taste buds."},
        {"Refreshing", "For creatures seeking something Refreshing, add <color=#0088AA>Celestial Ambrosia</color>. Heaven in the form of a liquid, just a touch of this topping will reinvigorate the creature."},
        {"Fluffy", "For creatures seeking something Fluffy, add <color=#0088AA>Pixie Clouds</color>. Produced by the flaps of pixie wings, this topping creates a delightful soft and airy texture."},
        {"Intense", "For creatures seeking something Intense, add <color=#0088AA>Dragon Tears</color>. Just one drop of this topping creates an explosive sensation when drank by the creature."},
        {"Novel", "For creatures seeking something Novel, add <color=#0088AA>Sunbeam Jelly</color>. Biting into this topping will make it pop, releasing the warm explosive flavours of the sun's rays."},
        {"Calming", "For creatures seeking something Calming, add <color=#0088AA>Magic Beans</color>. This topping settles on the tongue, creating a sense of nostalgia that soothes the soul."}
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