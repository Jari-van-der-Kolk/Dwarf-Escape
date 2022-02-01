using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    
    public class InventoryCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
    
        [SerializeField] private InventoryItemData itemData;
        private Image icon;
        private TextMeshProUGUI itemAmountDisplay;
    
        private void Awake()
        {
            icon = GetComponent<Image>();
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            if (itemData != null)
            {
                
            }
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    
        private void ApplyDAtaToCell(InventoryItem item)
        {
            icon.sprite = item.data.icon;
            itemAmountDisplay.text = item.stackSize.ToString();
        }
        
    }
}
