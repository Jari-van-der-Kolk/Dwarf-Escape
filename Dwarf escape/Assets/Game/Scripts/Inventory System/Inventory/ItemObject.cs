using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{

    public class ItemObject : MonoBehaviour, IInteract
    {
        public InventoryItemData referenceItem;
        private SpriteRenderer icon;

        private void Awake()
        {
            icon = GetComponent<SpriteRenderer>();
        }

        public void Action()
        {
            InventorySystem.instance.Add(referenceItem);
            //deactivate the object you are picking up
            Destroy(gameObject);
        }

        public string DisplayText()
        {
            return "";
        }
    }
}


/*
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public List<ItemRequirement> requirements;

    public bool removeRequirementsOnPickup;
    
    public void OnHandlePickupItem()
    {
        if (MeetsRequirements())
        {
            if (removeRequirementsOnPickup)
            {
                RemoveRequirements();
            }
        }
        InventorySystem.instance.Add(referenceItem);
        //deactivate the object you are picking up
        Destroy(gameObject);
    }

    private bool MeetsRequirements()
    {
        foreach (ItemRequirement requirement in requirements)
        {
            if(!requirement.HasRequirement()){return false;}
        }

        return true;
    }

    public void RemoveRequirements()
    {
        foreach (ItemRequirement requirement in requirements)
        {
            for (int i = 0; i < requirement.amount; i++)
            {
                InventorySystem.instance.Remove(requirement.itemData);
            }
        }
    }
}

[Serializable]
public struct ItemRequirement
{
    public InventoryItemData itemData;
    public int amount;

    public bool HasRequirement()
    {
        InventoryItem item = InventorySystem.instance.Get(itemData);

        if (item == null || item.stackSize < amount) { return false; }

        return true;
    }
}
*/
