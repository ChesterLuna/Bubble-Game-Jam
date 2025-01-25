using UnityEngine;

public class ClickableCreator : MonoBehaviour, ClickableAsset
{
    // Intented to be used for buttons that create objects

    [SerializeField] GameObject toInstantiate;
    GameObject objectInstantiated;

    public void OnClick()
    {
        print("Clicked on clickable creator, this should instantiate a game object as a child");
    }


    // While this is "creating the object"
    // I think it would be useful to just show and hide an specific object

    private void CreateAsset()
    {
        print("Create the toInstantiate game object");
        // Assign the created object to objectInstantiated
    }

    private void DestroyAsset()
    {
        print("Dekete the toInstantiate game object");
        // Destroy the created object in objectInstantiated
    }

}
