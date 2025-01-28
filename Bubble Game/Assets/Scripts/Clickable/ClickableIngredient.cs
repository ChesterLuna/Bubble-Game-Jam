using System;
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
    [SerializeField] AudioClip audioToplay;
    [SerializeField] GameObject clipPlayer;
    [SerializeField][Range(0f, 1f)] float vol = 1;

    GameObject bobaCreator;

    private void Start() {
        if (bobaCreator == null)
        {
            bobaCreator = GameObject.FindGameObjectWithTag("BobaCreator");
        }
    }

    public void OnClick()
    {
        bool value = true;
        if (isBase)
        {
            value = bobaCreator.GetComponent<BobaCreator>().AddBase(ingredientName, ingredientSprite);
        }
        else
        {
            value = bobaCreator.GetComponent<BobaCreator>().AddTopping(ingredientName, ingredientSprite);
        }
        if(value)
        {
            PlayClip();
        }

    }

    private void PlayClip()
    {
        if(audioToplay == null)
        {
            print("Tried to play a clip but was not able to");
            return;
        }
        GameObject source = Instantiate(clipPlayer);
        source.GetComponent<AudioSource>().clip = audioToplay;
        source.GetComponent<AudioSource>().volume = vol;
        source.GetComponent<AudioSource>().Play();
    }

    public void SwitchVisibility(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
