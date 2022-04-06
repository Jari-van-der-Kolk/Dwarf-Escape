using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class  InventorySlotManager : MonoBehaviour
{

    public int bitchAss;
    
    public static InventorySlotManager instance;

    [SerializeField] private List<InventorySlot> inventorySlots;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            var foo = transform.GetChild(i).GetComponent<InventorySlot>();
            inventorySlots.Add(foo);
        }
        
    } 
   
    public void Add(InventoryItem referenceData)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].referenceData.data == null)
            {
                inventorySlots[i].referenceData = referenceData;
                break;
            }
        }
    }
    
    
}
