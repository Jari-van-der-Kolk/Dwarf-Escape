using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equipment : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public InventoryItem referenceData;
    private TextMeshProUGUI counterText;
    
    private RectTransform m_RectTransform;
    
    private GameObject m_DraggingIcon;
    private RectTransform m_DraggingPlane;
    private CanvasGroup m_DraggingCanvasGroup;
    
    private CanvasGroup m_CanvasGroup;
    
    public bool dragOnSurfaces = true;
    private void OnEnable()
    {
        if (transform.childCount > 0)
        {
            TransformToOrigin();
            
        }
    }

    public void Init(InventoryItem referenceData, TextMeshProUGUI counterText)
    {
        this.referenceData = referenceData;
        this.counterText = counterText;

        this.counterText.text = referenceData.stackSize.ToString();
        m_CanvasGroup = GetComponent<CanvasGroup>();
        m_RectTransform = GetComponent<RectTransform>();
        GetComponent<Image>().sprite = referenceData.data.icon;
        m_RectTransform.position = m_RectTransform.parent.position;
        
        
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        m_DraggingIcon = Instantiate(gameObject, canvas.transform, false);
        m_DraggingIcon.transform.SetAsLastSibling();
        m_DraggingIcon.GetComponent<Image>().SetNativeSize();
        
        m_DraggingCanvasGroup = m_DraggingIcon.GetComponent<CanvasGroup>();
        m_DraggingCanvasGroup.blocksRaycasts = false;
        
        if (dragOnSurfaces)
            m_DraggingPlane = transform as RectTransform;
        else
            m_DraggingPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);

        m_CanvasGroup.alpha = .6f;
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (m_DraggingIcon != null)
            SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_CanvasGroup.alpha = 1f;
        m_CanvasGroup.blocksRaycasts = true;
        
        m_DraggingCanvasGroup.blocksRaycasts = true;
        
        if (m_DraggingIcon != null)
            Destroy(m_DraggingIcon);
    }
    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }
    
    private static T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }

    private void TransformToOrigin()
    {
        m_DraggingPlane = transform.GetComponentInParent<EquipmentSlot>().transform as RectTransform;
    }

    public void UpdateValue()
    {
        counterText.text = referenceData.stackSize.ToString();
    }
    
}
