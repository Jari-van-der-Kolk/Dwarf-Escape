using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TabGroup : MonoBehaviour
{

    public List<TabButton> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButton selectedTab;

    public List<GameObject> objectToSwap;

    public PanelGroup panelGroup;

    private DefaultInputActions _defaultInputActions;
    
    private void Awake()
    {
        _defaultInputActions = new DefaultInputActions();
        _defaultInputActions.UI.Navigate.performed += NextTab;
        StartActiveTab();
    }
    
    private void Start()
    {
        StartActiveTab();
    }

    private void OnEnable()
    {
        _defaultInputActions.UI.Enable();
    }

    private void OnDisable()
    {
        _defaultInputActions.UI.Disable();
        SetActive(0);
    }

    private void NextTab(InputAction.CallbackContext context)
    {
        if (_defaultInputActions.UI.Navigate.ReadValue<Vector2>() == Vector2.up)
        {
            Debug.Log(selectedTab);
            int nextTabIndex = selectedTab.transform.GetSiblingIndex() - 1;
            if (nextTabIndex < 0)
            {
                SetActive(transform.childCount - 1);
            }
            SetActive(nextTabIndex);
        }

        if (_defaultInputActions.UI.Navigate.ReadValue<Vector2>() == Vector2.down)
        {
            int nextTabIndex = selectedTab.transform.GetSiblingIndex() + 1;
            if (nextTabIndex > transform.childCount - 1)
            {
                SetActive(0);
                return;
            }
            SetActive(nextTabIndex);
        }
    }
    
    public void StartActiveTab()
    {
        if (selectedTab == null)
        {
            SetActive(0);            
        }
    }
    
    private void SetActive(TabButton tabButton)
    {
        foreach (TabButton t in tabButtons)
        {
            t.tabGroup.ResetTabs();
        }

        selectedTab = tabButton;
        selectedTab.tabGroup.OnTabSelected(tabButton);

        if (panelGroup != null)
        {
            panelGroup.SetPageIndex(tabButton.transform.GetSiblingIndex());
        }
    }

    public void SetActive(int siblingIndex)
    {
        foreach (var t in tabButtons)
        {
            if (t.transform.GetSiblingIndex() == siblingIndex)    
            {
                SetActive(t);
                return;
            }
        }
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab != null || button != selectedTab)
        {
            button.background.color = tabHover;
        }

    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;
        
        selectedTab.Select();
        
        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectToSwap.Count; i++)
        {
            if (i == index)
            {
                objectToSwap[i].SetActive(true);
            }
            else
            {
                if(!objectToSwap[i].gameObject.activeInHierarchy) continue;
                objectToSwap[i].SetActive(false);
            }
        }
    }
    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) continue;
            button.background.color = tabIdle;
        }
    }
    
}
