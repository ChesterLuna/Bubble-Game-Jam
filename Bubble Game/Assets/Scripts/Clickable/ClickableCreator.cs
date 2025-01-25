using UnityEngine;

public class ClickableCreator : MonoBehaviour, ClickableAsset
{
    // Intented to be used for buttons that create objects

    [SerializeField] GameObject toInstantiate;

    public void OnClick()
    {
        print("Clicked on clickable creator, this should instantiate a game object as a child");
    }
}
