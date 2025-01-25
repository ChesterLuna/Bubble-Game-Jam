using UnityEngine;

public class ClickableIngredient : MonoBehaviour, ClickableAsset
{
    // Intented to be used for the actual ingredients

    [SerializeField] string ingredientName = "";
    [SerializeField] bool isBase = false;

    [Header("Scoop Assets")] 
    // These options might be used if we drag the ingredientes
    [SerializeField] bool scoopable = false; // So bases wouldnt be scoopable
    [SerializeField] Sprite ingredientSprite;
    [SerializeField] Sprite singleIngredientSprite;

    GameObject bobaCreator;

    private void Start() {
        if (bobaCreator == null)
        {
            bobaCreator = GameObject.FindGameObjectWithTag("BobaCreator");
        }
    }

    public void OnClick()
    {
        if(isBase)
        {
            bobaCreator.GetComponent<BobaCreator>().AddBase(ingredientName, ingredientSprite);
        }
        else
        {
            bobaCreator.GetComponent<BobaCreator>().AddTopping(ingredientName, ingredientSprite);
        }
    }

}
