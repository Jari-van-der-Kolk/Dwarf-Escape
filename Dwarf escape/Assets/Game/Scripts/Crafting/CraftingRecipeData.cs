using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe")]
public class CraftingRecipeData : ScriptableObject
{
    public Recipe[] recipe;
}

[System.Serializable]
public class Recipe
{
    public string name;
    public InventoryItem item;
    public int amount;
}
