using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public string[] favoriteIngredients;

    public void CheckCorrectIngredients(string[] chosenIngredients)
    {
        int correctIngredients = 0;
        foreach (string ingredient in chosenIngredients)
        {
            if (favoriteIngredients.Contains(ingredient))
            {
                correctIngredients++;
            }
        }

        // Daily score counts how many orders were perfect
        // Global score counts how many ingredients were correct in perfect orders
        if(correctIngredients == favoriteIngredients.Length)
        {
            ScoringSystem.instance.dailyScore++;
            ScoringSystem.instance.globalScore += correctIngredients;
        }
        else
        {
            ScoringSystem.instance.dailyScore--;
        }

    }
    public bool HasCustomer()
    {
        return favoriteIngredients != null;
    }

    public void CleanCustomer()
    {
        favoriteIngredients = null;
    }

}
