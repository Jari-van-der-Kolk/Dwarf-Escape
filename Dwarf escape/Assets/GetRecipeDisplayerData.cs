using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetRecipeDisplayerData : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    private bool assigned;

    private void Start()
    {
        AssignTooltipData();
    }

    public void AssignTooltipData()
    {
        if (assigned == false)
        {
            TooltipRecipeData tooltipRecipeData = new TooltipRecipeData(image, text);
            TooltipSystem.SubscribeRecipeDisplayData(tooltipRecipeData);
            assigned = true;
        }
       
    }
    
    

   
}
