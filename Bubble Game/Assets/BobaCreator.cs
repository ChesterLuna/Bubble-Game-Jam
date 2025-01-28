using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BobaCreator : MonoBehaviour
{
    [SerializeField] public List<string> currentToppings;
    [SerializeField] public string currentBase;

    Image currentBaseImage;
    GameObject toppings;

    [SerializeField] GameObject toppingPrefab;
    [SerializeField] Customer customer;

    [SerializeField] GameObject levelManager;
    [SerializeField] Sprite transparentSprite;

    [SerializeField] DialogueController dialogueController;

    private void Start()
    {
        currentBase = "";
        currentBaseImage = transform.Find("Base").GetComponent<Image>();
        toppings = transform.Find("Toppings").gameObject;
        levelManager = GameObject.FindGameObjectWithTag("GameController");
    }

    public void AddBase(string newBase, Sprite newBaseImage)
    {
        if(currentBase != "")
        {
            return;
        }
        currentBase = newBase;
        currentBaseImage.sprite = newBaseImage;
    }

    public void AddTopping(string newTopping, Sprite newToppingImage)
    {
        if (currentToppings.Contains(newTopping))
        {
            return;
        }
        currentToppings.Add(newTopping);

        GameObject newToppingObject = Instantiate(toppingPrefab, toppings.transform);

        newToppingObject.GetComponent<Image>().sprite = newToppingImage;

    }

    public void DeleteBoba()
    {
        currentToppings.Clear();
        currentBase = "";

        currentBaseImage.sprite = transparentSprite;
        
        // Destroy all children
        int childrenCount = toppings.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            Destroy(toppings.transform.GetChild(i).gameObject);
        }
    }

    public void ServeBoba()
    {
        if (customer.favoriteIngredients == null || dialogueController.IsTalking())
        {
            print("Tried to serve drink but there is no customer or a customer is currently talking");
            return;
        }

        currentToppings.Add(currentBase);
        customer.CheckCorrectIngredients(currentToppings.ToArray());
        DeleteBoba();
        dialogueController.ClearDialogue();


        if (levelManager.GetComponent<Timer>().timeLeft >= 0)
        {
            levelManager.GetComponent<CustomerSpawner>().SpawnCustomer(ScenesManager.instance.currentDifficulty);
            dialogueController.DisplayText();
        }
        else
        {
            ScenesManager.instance.ChangeDay();
        }
    }


}
