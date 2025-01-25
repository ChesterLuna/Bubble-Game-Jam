using UnityEngine;

public class MainMenuController : MonoBehaviour {
    private GameObject optionsMenu = null;
    private GameObject credits = null;
    private GameObject startButton = null;
    private GameObject optionsButton = null;
    private GameObject creditsButton = null;

    private void Start() {
        optionsMenu = transform.Find("OptionsMenu").gameObject;
        credits = transform.Find("CreditsCanvas").gameObject;
        startButton = transform.Find("StartGameButton").gameObject;
        optionsButton = transform.Find("OptionsButton").gameObject;
        creditsButton = transform.Find("CreditsButton").gameObject;
        optionsMenu.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenOptions() {
        optionsMenu.SetActive(true);
        startButton.SetActive(false);
        optionsButton.SetActive(false);
        creditsButton.SetActive(false);
    }

    public void CloseOptions() {
        optionsMenu.SetActive(false);
        startButton.SetActive(true);
        optionsButton.SetActive(true);
        creditsButton.SetActive(true);
    }

    public void OpenCredits() {
        credits.SetActive(true);
        startButton.SetActive(false);
        optionsButton.SetActive(false);
        creditsButton.SetActive(false);
    }

    public void CloseCredits() {
        credits.SetActive(false);
        startButton.SetActive(true);
        optionsButton.SetActive(true);
        creditsButton.SetActive(true);
    }
}
