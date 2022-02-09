using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TooltipRecipeData
{
    public Image icon;
    public TextMeshProUGUI displayText;
    [HideInInspector] public GameObject gameObject;
    
    public TooltipRecipeData(GameObject gameObject ,Image icon, TextMeshProUGUI displayText)
    {
        this.gameObject = gameObject;
        this.icon = icon;
        this.displayText = displayText;
    }
    
   
}
