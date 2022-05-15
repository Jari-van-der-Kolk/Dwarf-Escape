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
    
    public void OnDrop(PointerEventData eventData)
    {
        var grabbedObject = eventData.pointerDrag.GetComponent<Equipment>();
        if (grabbedObject != null && HasChild() == false)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            eventData.pointerDrag.transform.parent = transform;
        }
    }

    private bool HasChild()
    {
        return transform.childCount > 0;
    }
   
}

