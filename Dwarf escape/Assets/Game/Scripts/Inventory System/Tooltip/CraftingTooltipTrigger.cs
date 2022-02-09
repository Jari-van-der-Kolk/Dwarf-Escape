using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string header;
    public CraftingRecipe content;

    private void Awake()
    {
        content = GetComponentInParent<CraftingRecipe>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.ShowCraftingRecipe(content, header);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerEnter(eventData);   
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.HideCraftingRecipe(content);
    }
    

    
}
