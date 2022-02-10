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
    [SerializeField] private GameObject upgrageInfoArea;


    [HideInInspector] public LayoutElement layoutElement;
    private RectTransform _rectTransform;

    public int characterWrapLimit;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        TooltipSystem.instance.craftingTooltip.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (!upgrageInfoArea.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        
        Vector2 position = TooltipSystem.mousePosition;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        _rectTransform.pivot = new Vector2(pivotX, pivotY); 
        transform.position = position;
    }

   
    public void Activate(CraftingRecipe recipe)
    {
        
        for (int i = 0; i <  recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length; i++)
        {
            string requirementDisplay;
            headerField.text = recipe.craftingRecipeData[recipe.craftingTier].name;
            TooltipSystem.instance.tooltipRecipeDatas[i].gameObject.SetActive(true);
            TooltipSystem.instance.tooltipRecipeDatas[i].image.sprite = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData.icon;
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
    
    public void Deactivate(CraftingRecipe recipe)
    {
        Debug.Log(TooltipSystem.instance.tooltipRecipeDatas[0]);
    }
}
