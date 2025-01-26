using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] string[] toppings;
    [SerializeField] string[] bases;

    [SerializeField] ScriptableObject[] species;

    [SerializeField] GameObject customerObject;
    Image mainBody;
    Image face;


    void Start()
    {
        mainBody = customerObject.transform.Find("MainBody").GetComponent<Image>();
        face = customerObject.transform.Find("Feature (1)").GetComponent<Image>();
        // string[]  ingredients = GenerateCustomer(4);

        // foreach(var a in ingredients)
        // {
        //     print( a);
        // }
    }

    public string[] SpawnCustomer(int maxToppings)
    {
        string[] ingredients = GenerateCustomerIngredients(maxToppings);
        string drinkBase = ingredients[0];
        Species currentSpecies = GetSpecies(drinkBase);

        // Generate Race
        Sprite speciesBody = currentSpecies.mainBody;
        mainBody.sprite = speciesBody;

        // Generate Features
        Sprite speciesFace = ChooseRandom(currentSpecies.faceFeatures);
        face.sprite = speciesFace;

        // Gives liked ingredients to the customer object
        // customerObject.GetComponent<Customer>().ingredients = ingredients;
        return ingredients;
    }

    private Species GetSpecies(string drinkBase)
    {
        foreach (Species theSpecies in species)
        {
            if(theSpecies.speciesName == drinkBase)
            {
                return theSpecies;
            }
        }
        Debug.LogError("Could not find a species related to that drinkBase");
        return null;
    }

    private string[] GenerateCustomerIngredients(int maxToppings)
    {
        int toppingNum = Random.Range(0, maxToppings);

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
            Debug.LogError("There are no Sprite choices.");
            return null;
        }

        Sprite chosenOption = choices[Random.Range(0, choices.Length)];
        return chosenOption;
    }

}
