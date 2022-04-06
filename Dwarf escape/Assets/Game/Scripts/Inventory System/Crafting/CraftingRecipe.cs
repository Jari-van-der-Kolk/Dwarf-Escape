using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.Events;

public class CraftingRecipe : MonoBehaviour
{
    public int craftingTier;
    public int maxTier;
    [SerializeField] private bool useTiers; // activate useTiers if you use the script for upgrading items
    public CraftingRecipeData[] craftingRecipeData;
    [SerializeField] private UnityEvent action;

    private void Start()
    {
        craftingTier = 0;
        maxTier = craftingRecipeData.Length - 1;
    }

    public void Craft()
    {
        if (CheckAmount())
        {
            RemoveUsedItems();
            action?.Invoke();
        }
    }

    private bool CheckAmount()
    {
        int requirementAmount = craftingRecipeData[craftingTier].requiredItems.Length;
        for (int i = 0; i < requirementAmount; i++)
        {
            InventoryItem item = InventorySystem.instance.Get(craftingRecipeData[craftingTier].requiredItems[i].itemData);
            if (item == null || item.stackSize < craftingRecipeData[craftingTier].requiredItems[i].amount)
            {
                Debug.Log("items missing");
                return false;
            }
        }
        return true;
    }

    private void RemoveUsedItems()
    {
        for (int i = 0; i < craftingRecipeData[craftingTier].requiredItems.Length; i++)
        {
            for (int j = 0; j < craftingRecipeData[craftingTier].requiredItems[i].amount; j++)
            {
                InventoryItem item = InventorySystem.instance.Get(craftingRecipeData[craftingTier].requiredItems[j].itemData);
                item.RemoveFromStack();
            }
        }
    }

    public void AddTier() => craftingTier++;

}


/*int requirementAmount = craftingRecipeData[craftingTier].requiredItems.Length;
for (int i = 0; i < requirementAmount; i++)
{
    InventoryItem item = InventorySystem.instance.Get(craftingRecipeData[craftingTier].requiredItems[i].itemData);
    //checks amount for one item at a time
    if (CheckAmount(item, i) == false) return;
}*/


/*
public class KeyRequirement : MonoBehaviour, IInteract
{
    public InventoryItemData referenceItem;

    private int interactedAmount;
    private InventoryItem keyItem;
    private void Start()
    {
        interactedAmount = 0;
    }

    public void Action()
    {
        interactedAmount++;
        keyItem = InventorySystem.instance.Get(referenceItem);
        if (keyItem == null)
        {
            return;
        }
        InventorySystem.instance.Remove(referenceItem);
        Destroy(gameObject);
    }

    public string DisplayText()
    {
        if (interactedAmount < 1)
        {
            return "Press [E] to open door";
        }
        else if(interactedAmount >= 1 ||keyItem != null)
        {
            return "Press [E] to open door";
        }
        return "You cannot open the Door without its key";
    }
*/
//}