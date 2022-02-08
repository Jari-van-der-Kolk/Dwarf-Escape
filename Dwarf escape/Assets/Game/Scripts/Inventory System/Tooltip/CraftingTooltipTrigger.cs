using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public CraftingRecipe content;


    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.ShowCraftingRecipe(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.HideCraftingRecipe();
    }
}
