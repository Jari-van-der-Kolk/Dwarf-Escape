using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem instance;

    public Tooltip tooltip;
    
    private InputSystemUIInputModule inputModule;

    
    public static Vector2 mousePosition
    {
        get { return instance == null ? new Vector2() : instance.inputModule.point.action.ReadValue<Vector2>(); }
    }
    
    public void Awake()
    {
        inputModule = FindObjectOfType<InputSystemUIInputModule>();
        instance = this;
    }

    public static void Show(string content, string header = "")
    {
        instance.tooltip.SetText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }

    /*public static void Show(CraftingTooltipData content, string header = "") 
    {
        //instance
    }*/

    public static void Hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }
    
   
}
