using System;
using UnityEngine;
using Inventory;
using TMPro;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
   public InventoryItem referenceData;

   private Image icon;
   private TextMeshProUGUI _counterText;

   public void Init(InventoryItem referenceData, Image icon,TextMeshProUGUI counterText)
   {
        this.referenceData = referenceData;
        icon.sprite = referenceData.data.icon;
        
        this.icon = icon;

        counterText.text = referenceData.stackSize.ToString();
        _counterText = counterText;

        GameEvents.instance.updateResourceValues += UpdateValue;
   }

    private void UpdateValue()
    {
        _counterText.text = referenceData.stackSize.ToString();
    }
}
