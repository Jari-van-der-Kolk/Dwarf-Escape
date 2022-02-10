using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipInformationTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string content;

    [SerializeField] private float showDelay = .75f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.ShowInformation(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.HideInformation();
    }

    private void OnDisable()
    {
        if (TooltipSystem.instance != null)
        {
            TooltipSystem.HideInformation();
        }
    }
} 
   
