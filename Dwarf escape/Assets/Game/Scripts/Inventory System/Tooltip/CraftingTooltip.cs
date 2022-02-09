using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingTooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    
    [SerializeField] private GameObject craftingInformationPrefab;

    public Transform contentField;


    [HideInInspector] public LayoutElement layoutElement;
    
    public RectTransform rectTransform;

    public int characterWrapLimit;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        TooltipSystem.instance.craftingTooltip.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        
        
        Vector2 position = TooltipSystem.mousePosition;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY); 
        transform.position = position;
    }

    public void ShowCraftingRecipe(CraftingRecipe recipe)
    {
        CheckOutOffBounds(recipe);
        Activate(recipe);
    }

    private void CheckOutOffBounds(CraftingRecipe recipe)
    {
        if (recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length > contentField.childCount)
        {
            int index = recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length - contentField.childCount;
            CreateDisplayersNeeded(index);
        }

    }
    private void Activate(CraftingRecipe recipe)
    {
        for (int i = 0; i <  recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length; i++)
        {
            string requirementDisplay;
            headerField.text = recipe.craftingRecipeData[recipe.craftingTier].name;
            TooltipSystem.instance.tooltipRecipeDatas[i].gameObject.SetActive(true);
            TooltipSystem.instance.tooltipRecipeDatas[i].icon.sprite = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData.icon;
            if (InventorySystem.instance.Get(recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData) != null)
            {
                requirementDisplay = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].amount.ToString();
                TooltipSystem.instance.tooltipRecipeDatas[i].displayText.text = 
                    InventorySystem.instance.Get(recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData).stackSize + "/" + requirementDisplay;
            }
            else
            {
                requirementDisplay = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].amount.ToString();
                TooltipSystem.instance.tooltipRecipeDatas[i].displayText.text = 0 + "/" + requirementDisplay;
            }
        }
        
    }
    private void CreateDisplayersNeeded(int index)
    {
        for (int i = 0; i < index; i++)
        {
            var obj = Instantiate(craftingInformationPrefab, contentField);
            obj.GetComponent<GetRecipeDisplayerData>().AssignTooltipData();
            
        }     
    }
    public void Deactivate(CraftingRecipe recipe)
    {
        for (int i = 0; i < recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length; i++)
        {
            TooltipSystem.instance.tooltipRecipeDatas[i].gameObject.SetActive(false);
        }
    }
}
