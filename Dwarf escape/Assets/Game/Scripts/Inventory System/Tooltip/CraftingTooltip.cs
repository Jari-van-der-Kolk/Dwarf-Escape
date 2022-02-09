using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingTooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;

    public Transform contentField;
    [SerializeField] private GameObject craftingInformationPrefab;

    [HideInInspector] public LayoutElement layoutElement;
    
    public RectTransform rectTransform;

    public int characterWrapLimit;

    private int i;
    
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
        //check if there are not enough images for the recipe
        CheckOutOffBounds(recipe);

        
        Activate(recipe);
    }

    private void CheckOutOffBounds(CraftingRecipe recipe)
    {
        if (recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length > contentField.childCount)
        {

            int index = recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length - contentField.childCount;
            Debug.Log("??");
            CreateDisplayersNeeded(index);
        }
    }

    private void Activate(CraftingRecipe recipe)
    {
        
        //Debug.Log( TooltipSystem.instance.tooltipRecipeDatas.Count);

        while (i < recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length)
        {
//            TooltipSystem.instance.tooltipRecipeDatas[i].icon.sprite = recipe.craftingRecipeData[recipe.craftingTier].requiredItems[i].itemData.icon;
            //Debug.Log(i);
            i++;
        }
        //Debug.Log( TooltipSystem.instance.tooltipRecipeDatas.Count + " " + recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length);

        // for (int i = 0; i < recipe.craftingRecipeData[recipe.craftingTier].requiredItems.Length; i++)
        // {
        //     
        // }
    }

    public void Deactivate()
    {
        
    }

    private void CreateDisplayersNeeded(int index)
    {
        for (int i = 0; i < index; i++)
        {
            Debug.Log(i);
            var obj = Instantiate(craftingInformationPrefab, contentField);
            obj.GetComponent<GetRecipeDisplayerData>().AssignTooltipData();
        }     
    }
  
    
    
}


/*public void SetText(string content, string header = "")
{
    if (string.IsNullOrEmpty(header))
    {
        headerField.gameObject.SetActive(false);
    }
    else
    {
        headerField.gameObject.SetActive(true);
        headerField.text = header;
    }

    contentField.text = content;
        
    int headerLength = headerField.text.Length;
    int contentLength = contentField.text.Length;

    layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;

}*/