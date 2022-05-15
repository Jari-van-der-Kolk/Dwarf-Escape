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
     private TextMeshProUGUI _counterText;
    
    private RectTransform _rectTransform;
    
    private GameObject _draggingIcon;
    private RectTransform _draggingPlane;
    private CanvasGroup _draggingCanvasGroup;
    
    private CanvasGroup _canvasGroup;
    
    public bool dragOnSurfaces = true;

    public void Init(InventoryItem referenceData, TextMeshProUGUI counterText)
    {
        this.referenceData = referenceData;
        _counterText = counterText;

        _counterText.text = referenceData.stackSize.ToString();
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        GetComponent<Image>().sprite = referenceData.data.icon;
        _rectTransform.position = _rectTransform.parent.position;
        
        EquipmentSlotManager.updateValues += UpdateValue;

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        _draggingIcon = Instantiate(gameObject, canvas.transform, false);
        _draggingIcon.transform.SetAsLastSibling();
        _draggingIcon.GetComponent<Image>().SetNativeSize();
        
        _draggingCanvasGroup = _draggingIcon.GetComponent<CanvasGroup>();
        _draggingCanvasGroup.blocksRaycasts = false;
        
        if (dragOnSurfaces)
            _draggingPlane = transform as RectTransform;
        else
            _draggingPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);

        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_draggingIcon != null)
            SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        
        _draggingCanvasGroup.blocksRaycasts = true;
        
        if (_draggingIcon != null)
            Destroy(_draggingIcon);
    }
    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            _draggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = _draggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = _draggingPlane.rotation;
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

    private void UpdateValue(object sender, EventArgs e)
    {
        _counterText.text = referenceData.stackSize.ToString();
    }
    
}
