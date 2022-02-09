using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TooltipRecipeData
{
    public Image icon;
    public TextMeshProUGUI text;
    
    public TooltipRecipeData(Image icon, TextMeshProUGUI text)
    {
        this.icon = icon;
        this.text = text;
    }
    
   
}
