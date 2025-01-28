using UnityEngine;
using UnityEngine.UI;

public class ClickableButton : MonoBehaviour, ClickableAsset
{

    public Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 1f;
    }

    // Intented to be used for general UI buttons
    public void OnClick()
    {
        print("This button has no implementation");
    }

    public void SwitchVisibility(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void HideObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void ShowObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
