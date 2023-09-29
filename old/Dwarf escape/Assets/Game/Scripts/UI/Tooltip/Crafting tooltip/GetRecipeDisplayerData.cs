using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetRecipeDisplayerData : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI displayText;
    public GameObject recipeDataGameObject;
    private bool assigned = false;

    private void OnEnable()
    {
        AssignTooltipData();
    }

    public void AssignTooltipData()
    {
        if (assigned == false)
        {
            recipeDataGameObject = gameObject;
            displayText = GetComponentInChildren<TextMeshProUGUI>();
            image.GetComponentInChildren<Image>();
            TooltipSystem.SubscribeRecipeDisplayData(this);
            assigned = true;
        }
       
    }
    
    

   
}
