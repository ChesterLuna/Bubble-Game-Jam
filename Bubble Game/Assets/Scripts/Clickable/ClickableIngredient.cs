using UnityEngine;

public class ClickableIngredient : MonoBehaviour, ClickableAsset
{
    // Intented to be used for the actual ingredients

    [SerializeField] string ingredientName = "";

    [Header("Scoop Assets")] 
    // These options might be used if we drag the ingredientes
    [SerializeField] bool scoopable = false; // So bases wouldnt be scoopable
    [SerializeField] Sprite ingredientSprite;
    [SerializeField] Sprite singleIngredientSprite;

    public void OnClick()
    {
        print(ingredientName + " was clicked");
    }

}
