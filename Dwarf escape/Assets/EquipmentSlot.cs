using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EquipmentSlot : MonoBehaviour, IDropHandler
{
     public InventoryItem referenceData;
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
        var foo = eventData.pointerDrag.GetComponent<Equipment>();
        if (foo != null && HasChild() == false)
        {
            referenceData = foo.referenceData;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            eventData.pointerDrag.transform.parent = transform;
        }
        else if (foo == null)
        {
            referenceData = null;
        }
       
    }

    private bool HasChild()
    {
        if (transform.childCount > 0)
        {
            return true;
        }
        
        return false;
    }
   
}

