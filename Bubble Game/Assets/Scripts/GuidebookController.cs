using UnityEngine;
using TMPro;

public class GuidebookController : MonoBehaviour {
    private string page1;
    private string page2;

    private TextMeshProUGUI textComponent = null;
    private GameObject nextButton = null;
    private GameObject prevButton = null;

    private void Start() {
        textComponent = transform.Find("GuideText").GetComponent<TextMeshProUGUI>();
        nextButton = transform.Find("NavigationButtonNext").gameObject;
        prevButton = transform.Find("NavigationButtonPrev").gameObject;
        prevButton.SetActive(false);
        page1 = "Species";
        page2 = "Toppings";
        textComponent.text = page1;
    }

}