using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] string[] toppings = new string[] {
        "boba",
        "flecks",
        "sugar",
        "truffle",
        "kumquat",
        "ambrosia",
        "clouds",
        "tears",
        "jelly",
        "beans"
    };
    [SerializeField] string[] bases = new string[] {
        "chewy",
        "luxe",
        "saccharine",
        "earthy",
        "citrusy",
        "refreshing",
        "fluffy",
        "intense",
        "novel",
        "calming"
    };

    [SerializeField] ScriptableObject[] species;

    [SerializeField] GameObject customerObject;
    [SerializeField] Image mainBody;
    [SerializeField] Image hair;
    [SerializeField] Image clothes;
    [SerializeField] Image other;
    [SerializeField] Sprite transparentSprite;
    [SerializeField] GameObject dialogue;

    public GameObject player;
    public AudioClip bells;
    [SerializeField][Range(0f, 1f)] float vol = 1;

    void Start()
    {
        mainBody = customerObject.transform.Find("MainBody").GetComponent<Image>();
        hair = customerObject.transform.Find("Hair").GetComponent<Image>();
        clothes = customerObject.transform.Find("Clothes").GetComponent<Image>();
        other = customerObject.transform.Find("Other").GetComponent<Image>();


        dialogue.GetComponent<DialogueController>().QueueSequenceDialogue(ScenesManager.instance.currentDay);

    }


    public string[] SpawnCustomer(int maxToppings)
    {
        string[] ingredients = GenerateCustomerIngredients(maxToppings);
        string drinkBase = ingredients[0];
        Species currentSpecies = GetSpecies(drinkBase);

        // Generate Race
        Sprite speciesBody = ChooseRandom(currentSpecies.mainBody);
        mainBody.sprite = speciesBody;

        // Generate Features
        Sprite hairFeature = ChooseRandom(currentSpecies.hairFeatures);
        hair.sprite = hairFeature;
        Sprite clothesFeature = ChooseRandom(currentSpecies.clothesFeatures);
        clothes.sprite = clothesFeature;
        Sprite otherFeature = ChooseRandom(currentSpecies.otherFeatures);
        other.sprite = otherFeature;

        // Gives liked ingredients to the customer object
        customerObject.GetComponent<Customer>().favoriteIngredients = ingredients;
        dialogue.GetComponent<DialogueController>().QueuePreferences(drinkBase, ingredients);
        GameObject source = Instantiate(player);
        source.GetComponent<AudioSource>().clip = bells;
        source.GetComponent<AudioSource>().volume = vol;
        source.GetComponent<AudioSource>().Play();

        return ingredients;
    }

    public void CleanCustomer()
    {
        mainBody.sprite = transparentSprite;
        hair.sprite = transparentSprite;
        clothes.sprite = transparentSprite;
        other.sprite = transparentSprite;

        customerObject.GetComponent<Customer>().CleanCustomer();
        dialogue.GetComponent<DialogueController>().ClearDialogue();
    }



    private Species GetSpecies(string drinkBase)
    {
        foreach (Species theSpecies in species)
        {
            if (theSpecies.speciesName == DrinkOptionHub.instance.drinksToSpecies[drinkBase])
            {
                return theSpecies;
            }
        }
        Debug.LogError("Could not find a species related to that drinkBase");
        return null;
    }

    private string[] GenerateCustomerIngredients(int maxToppings)
    {
        int toppingNum = Random.Range(1, maxToppings + 1);

        List<string> chosenToppings = new List<string>();
        string chosenBase = ChooseRandom(bases);
        
        // For now, just mix the base and the toppings.
        chosenToppings.Add(chosenBase);

        // Infinite Loop if toppingNum over availableIngredients
        while (chosenToppings.Count() < toppingNum + 1)
        {
            string randTopping = ChooseRandom(toppings);

            if (!chosenToppings.Contains(randTopping))
            {
                chosenToppings.Add(randTopping);
            }
        }

        return chosenToppings.ToArray();
    }

    private string ChooseRandom(string[] choices)
    {
        if(choices.Length == 0)
        {
            Debug.LogError("There are no string choices.");
            return null;
        }

        string chosenOption = choices[Random.Range(0, choices.Length)];
        return chosenOption;
    }
    
    private Sprite ChooseRandom(Sprite[] choices)
    {
        if (choices.Length == 0)
        {
            print("There are no Sprite choices.");
            return transparentSprite;
        }

        Sprite chosenOption = choices[Random.Range(0, choices.Length)];
        return chosenOption;
    }

}
