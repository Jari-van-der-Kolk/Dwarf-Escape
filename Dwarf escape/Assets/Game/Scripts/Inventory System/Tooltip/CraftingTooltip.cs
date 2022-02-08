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

    private List<Image> craftingImages;

    
    [HideInInspector] public LayoutElement layoutElement;
    
    public int characterWrapLimit;

    public RectTransform rectTransform;
    
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    
    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit) ? true : false;
        }

        Vector2 position = TooltipSystem.mousePosition;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY); 
        transform.position = position;
    }


    public void SetCraftingRecipe(CraftingRecipe recipe)
    {
        CheckOutOffBounds(recipe);
        Activate(recipe);
    }

    private void CheckOutOffBounds(CraftingRecipe recipe)
    {
        if (recipe.craftingRecipeData.Length > contentField.childCount)
        {
            Instantiate(craftingInformationPrefab, contentField);
        }
    }

    private void Activate(CraftingRecipe recipe)
    {
        for (int i = 0; i < recipe.craftingRecipeData.Length; i++)
        {
                 
        }
    }

    public void Deactivate()
    {
        
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