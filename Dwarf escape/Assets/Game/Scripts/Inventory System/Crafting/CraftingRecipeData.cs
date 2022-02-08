using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe")]
public class CraftingRecipeData : ScriptableObject
{
    public Recipe[] requiredItems;
}

[System.Serializable]
public class Recipe
{
    public string name;
    public InventoryItemData itemData;
    public int amount;
}

