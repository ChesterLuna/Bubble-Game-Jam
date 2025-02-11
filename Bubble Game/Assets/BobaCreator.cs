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
    [SerializeField] Button serveButton;

    private void Start()
    {
        currentBase = "";
        currentBaseImage = transform.Find("Base").GetComponent<Image>();
        toppings = transform.Find("Toppings").gameObject;
        levelManager = GameObject.FindGameObjectWithTag("GameController");
    }

    public bool AddBase(string newBase, Sprite newBaseImage)
    {
        if(currentBase != "")
        {
            return false;
        }
        currentBase = newBase;
        currentBaseImage.sprite = newBaseImage;
        return true;
    }

    public bool AddTopping(string newTopping, Sprite newToppingImage)
    {
        if (currentToppings.Contains(newTopping))
        {
            return false;
        }
        currentToppings.Add(newTopping);

        GameObject newToppingObject = Instantiate(toppingPrefab, toppings.transform);

        newToppingObject.GetComponent<Image>().sprite = newToppingImage;
        return true;

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

    private void Update()
    {
        if (customer.favoriteIngredients == null || dialogueController.IsTalking())
        {
            serveButton.interactable = false;
        }
        else
        {
            serveButton.interactable = true;
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
            levelManager.GetComponent<CustomerSpawner>().CleanCustomer();
            dialogueController.DisplayOutro();
        }
    }


}
