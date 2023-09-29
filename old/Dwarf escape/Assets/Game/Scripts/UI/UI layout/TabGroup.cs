using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TabGroup : MonoBehaviour
{

    public List<TabButtons> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButtons selectedTab;

    public List<GameObject> objectToSwap;

    public PanelGroup panelGroup;

    private DefaultInputActions _defaultInputActions;
    
    private void Awake()
    {
        _defaultInputActions = new DefaultInputActions();
        _defaultInputActions.UI.Navigate.performed += NextTab;
    }

    // hier zou je in de problemen kunnen komen met het niet gebreuken van de StartActiveTab method

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
    
    private void SetActive(TabButtons tabButton)
    {
        foreach (TabButtons t in tabButtons)
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

    public void Subscribe(TabButtons button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButtons>();
        }
        
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButtons button)
    {
        ResetTabs();
        if (selectedTab != null || button != selectedTab)
        {
            button.background.color = tabHover;
        }

    }
    public void OnTabExit(TabButtons button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButtons button)
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
        foreach (TabButtons button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) continue;
            button.background.color = tabIdle;
        }
    }
    
}
