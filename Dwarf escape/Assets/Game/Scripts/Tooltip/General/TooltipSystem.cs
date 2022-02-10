using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem instance;
    public Tooltip tooltip;
    public CraftingTooltip craftingTooltip;


    [SerializeField] private GameObject craftingInformationPrefab;
    [SerializeField] private Transform contentField;
    
    [HideInInspector]public List<GetRecipeDisplayerData> tooltipRecipeDatas;
    private InputSystemUIInputModule inputModule;

    
    public static Vector2 mousePosition
    {
        get { return instance == null ? new Vector2() : instance.inputModule.point.action.ReadValue<Vector2>(); }
    }
    
    public void Awake()
    {
        inputModule = FindObjectOfType<InputSystemUIInputModule>();
        instance = this;
    }

    public static void ShowCraftingRecipe(CraftingRecipe content, string header = "")
    {
        instance.Deactivate();
        instance.craftingTooltip.UpdatePosition();
        instance.CheckOutOffBounds(content);
        instance.Activate(content, header);   
        instance.craftingTooltip.gameObject.SetActive(true);
    }

    public static void HideCraftingRecipe(CraftingRecipe content)
    {
        instance.craftingTooltip.gameObject.SetActive(false);
    }
  
    public static void ShowInformation(string content, string header = "")
    {
        instance.tooltip.SetText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }
    
    public static void HideInformation()
    {
        instance.tooltip.gameObject.SetActive(false);
    }

    private void CheckOutOffBounds(CraftingRecipe recipe)
    {
        if (recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length > contentField.childCount)
        {
            int index = recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length - contentField.childCount;
            CreateDisplay(index);
        }

    }
    private void CreateDisplay(int index)
    {
        for (int i = 0; i < index; i++)
        {
            var obj = Instantiate(craftingInformationPrefab, contentField);
            obj.GetComponent<GetRecipeDisplayerData>().AssignTooltipData();
        }     
    }

    public static void SubscribeRecipeDisplayData(GetRecipeDisplayerData tooltipRecipeData)
    {
        if (instance.tooltipRecipeDatas == null)
        {
            instance.tooltipRecipeDatas = new List<GetRecipeDisplayerData>();
        }

        instance.tooltipRecipeDatas.Add(tooltipRecipeData);
    }
    
    private void Activate(CraftingRecipe recipe, string header = "")
    {
        for (int i = 0; i <  recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length; i++)
        {
            string requirementDisplay;
            instance.craftingTooltip.headerField.text = recipe.craftingRecipeData[recipe.craftingTier].name;
            instance.tooltipRecipeDatas[i].gameObject.SetActive(true);
            instance.tooltipRecipeDatas[i].image.sprite = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData.icon;
            if (InventorySystem.instance.Get(recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData) != null)
            {
                requirementDisplay = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].amount.ToString();
                instance.tooltipRecipeDatas[i].displayText.text = 
                    InventorySystem.instance.Get(recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData).stackSize + "/" + requirementDisplay;
            }
            else
            {
                requirementDisplay = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].amount.ToString();
                instance.tooltipRecipeDatas[i].displayText.text = 0 + "/" + requirementDisplay;
            }
        }
    }

    private void Deactivate()
    {
        for (int i = 0; i < instance.contentField.childCount; i++)
        {
            instance.tooltipRecipeDatas[i].gameObject.SetActive(false);
        }
    }
}
