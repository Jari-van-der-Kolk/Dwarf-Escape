using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class  EquipmentSlotManager : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;

    public static EquipmentSlotManager instance;

    [SerializeField] private List<EquipmentSlot> equipmentSlots;

    public static EventHandler updateValues;

    private Vector3 _mainPos;

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
            Debug.LogWarning("hierarchy has two or more of these components");;
            Destroy(this);
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            var equipmentSlotMember = transform.GetChild(i).GetComponent<EquipmentSlot>();
            equipmentSlots.Add(equipmentSlotMember);
        }

    }
    
    public void Add(InventoryItem referenceData)
    {
        for (int i = 0; i < equipmentSlots.Count; i++)
        {
            if (equipmentSlots[i].transform.childCount <= 0)
            {
                var equipment = new GameObject("Equipment", typeof(Image), typeof(Equipment), typeof(CanvasGroup));
                var text = Instantiate(textPrefab, equipment.transform);
                
                equipment.transform.parent = equipmentSlots[i].transform;
                equipment.GetComponent<Equipment>().Init(referenceData, text.GetComponent<TextMeshProUGUI>());
                break;
            }
        }
    }
}
