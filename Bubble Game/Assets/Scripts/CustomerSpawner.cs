using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] string[] toppings ;
    [SerializeField] string[] bases;


    void Start()
    {
        // string[]  ingredients = GenerateCustomer(4);

        // foreach(var a in ingredients)
        // {
        //     print( a);
        // }
    }

    

    public string[] GenerateCustomerIngredients(int maxToppings)
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

    private dynamic ChooseRandom(dynamic[] choices)
    {
        dynamic chosenOption = choices[Random.Range(0, choices.Length)];
        return chosenOption;
    }

}
