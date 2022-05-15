using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{

    public enum ItemType
    {
        Equipment,
        Resource
    }
    
    [CreateAssetMenu(menuName = "Inventory Item Data")]
    public class InventoryItemData : ScriptableObject
    {
        public ItemType itemType;
        public string id;
        public string displayName;
        public int tier = 1;
        public Sprite icon;
        public bool debugMode;
        public GameObject prefab;
    }
}
