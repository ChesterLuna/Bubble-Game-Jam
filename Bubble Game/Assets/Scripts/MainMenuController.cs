using UnityEngine;

public class MainMenuController : MonoBehaviour {
    private GameObject optionsMenu = null;
    private GameObject credits = null;

    private void Start() {
        optionsMenu = transform.Find("OptionsMenu").gameObject;
        credits = transform.Find("CreditsCanvas").gameObject;
        optionsMenu.SetActive(false);
        credits.SetActive(false);
        Debug.Log(optionsMenu);
        Debug.Log(credits);
    }
}
