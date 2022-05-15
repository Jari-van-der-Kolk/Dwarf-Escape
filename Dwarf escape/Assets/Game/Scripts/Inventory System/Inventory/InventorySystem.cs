using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{

    public class InventorySystem : MonoBehaviour
    {
        public static InventorySystem instance;

        private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
        private List<InventoryItem> inventory { get; set; }

        void Awake()
        {
            Init();
        }

        public void Init()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != null)
            {
                Destroy(this);
            }

            inventory = new List<InventoryItem>();
            _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        }

        public InventoryItem Get(InventoryItemData referenceData)
        {
            if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            {
                return value;
            }
            return null;
        }

        
        //maak een AddMaterial method en een AddEquipable method
        public void Add(InventoryItemData referenceData)
        {
            if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            {
                value.AddToStack();
                
                switch (referenceData.itemType)
                {
                    case ItemType.Equipment:
                        EquipmentSlotManager.updateValues?.Invoke(this, EventArgs.Empty);
                        break;
                    case ItemType.Resource:
                        ResourceManager.updateValues?.Invoke(this, EventArgs.Empty);
                        break;
                }
               
            }
            else
            {
                InventoryItem newItem = new InventoryItem(referenceData);
                inventory.Add(newItem);
                _itemDictionary.Add(referenceData, newItem);

                switch (referenceData.itemType)
                {
                    case ItemType.Equipment:
                        EquipmentSlotManager.instance.Add(newItem); 
                        break;
                    case ItemType.Resource:
                        ResourceManager.instance.Add(newItem);
                        break;
                }
              
            }
        }

        public void Remove(InventoryItemData referenceData)
        {
            if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            {
                value.RemoveFromStack();

                if (value.stackSize == 0)
                {
                    inventory.Remove(value);
                    _itemDictionary.Remove(referenceData);
                }
            }
        }

    }
}