using System.Linq;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] string[] toppings ;
    [SerializeField] string[] bases;


    void Start() {
        print(GenerateCustomer(4));
    }

    

    public string[] GenerateCustomer(int maxToppings)
    {
        int toppingNum = Random.Range(0, maxToppings);

        string[] chosenToppings = new string[0];
        string chosenBase = "";

        chosenBase = ChooseRandom(bases);
        // For now, just mix the base and the toppings.
        chosenToppings.Append(chosenBase);

        // Infinite Loop if toppingNum over availableIngredients
        while (chosenToppings.Length < toppingNum)
        {
            string randTopping = ChooseRandom(toppings);

            if (chosenToppings.Contains(randTopping))
            {
                chosenToppings.Append(randTopping);
            }
        }


        return chosenToppings;

    }

    private string ChooseRandom(string[] strings)
    {
        string chosenString = strings[Random.Range(0, strings.Length)];
        return chosenString;
    }

}
