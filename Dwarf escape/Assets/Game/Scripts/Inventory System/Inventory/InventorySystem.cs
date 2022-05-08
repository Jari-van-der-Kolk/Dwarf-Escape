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
        public List<InventoryItem> inventory { get; private set; }

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
                EquipmentSlotManager.updateValues?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                InventoryItem newItem = new InventoryItem(referenceData);
                inventory.Add(newItem);
                _itemDictionary.Add(referenceData, newItem);
                EquipmentSlotManager.instance.Add(newItem);
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