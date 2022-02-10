using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem instance;

    public Tooltip tooltip;
    public CraftingTooltip craftingTooltip;

    public List<GetRecipeDisplayerData> tooltipRecipeDatas;
    
    private InputSystemUIInputModule inputModule;

    [SerializeField] private GameObject craftingInformationPrefab;
    [SerializeField] private Transform contentField;

    
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
        for (int i = 0; i < instance.contentField.childCount; i++)
        {
            instance.tooltipRecipeDatas[i].gameObject.SetActive(false);
        }
        instance.CheckOutOffBounds(content);
        instance.craftingTooltip.Activate(content);   
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
            CreateDisplayersNeeded(index);
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

    public static void SubscribeRecipeDisplayData(GetRecipeDisplayerData tooltipRecipeData)
    {
        if (instance.tooltipRecipeDatas == null)
        {
            instance.tooltipRecipeDatas = new List<GetRecipeDisplayerData>();
        }

        instance.tooltipRecipeDatas.Add(tooltipRecipeData);
    }
}
