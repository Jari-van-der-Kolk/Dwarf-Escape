using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingTooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    [SerializeField] private GameObject upgrageInfoArea;


    [HideInInspector] public LayoutElement layoutElement;
    private RectTransform _rectTransform;

    public int characterWrapLimit;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        TooltipSystem.instance.craftingTooltip.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (!upgrageInfoArea.activeInHierarchy)
        {
            Debug.Log("yeet");
            gameObject.SetActive(false);
        }
        
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        Vector2 position = TooltipSystem.mousePosition;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        _rectTransform.pivot = new Vector2(pivotX, pivotY); 
        transform.position = position;
    }
    
    
}
