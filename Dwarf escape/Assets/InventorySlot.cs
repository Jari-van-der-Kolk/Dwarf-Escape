using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //zorg ervoor dat hij de juiste plaatje laat zien en de hoeveelheid
    //als de cursor over de slot heen gaat dan moet de slot moet de slot ruimte maken om naar links of naar rechts te gaan


    private Image m_image;
    private TextMeshProUGUI m_amountText;
    public InventoryItem referenceData;

    private void Awake()
    {
        m_image = GetComponent<Image>();
        m_amountText = GetComponentInChildren<TextMeshProUGUI>();

    }

    private void OnEnable()
    {
        AssignData();
    }

    private void AssignData()
    {
        if (referenceData.data != null)
        {
            m_image.sprite = referenceData.data.icon;
            m_amountText.text = referenceData.stackSize.ToString();
        }
       
    }

    
}
