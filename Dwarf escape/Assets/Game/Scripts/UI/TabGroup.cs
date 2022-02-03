using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{

    public List<TabButton> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButton selectedTab;

    public List<GameObject> objectToSwap;

    public PanelGroup panelGroup;

    private void Start()
    {
        StartActiveTab();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedTab.transform.GetSiblingIndex() > 0)
            {
                SetActive(selectedTab.transform.GetSiblingIndex() - 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedTab.transform.GetSiblingIndex() < (transform.childCount - 1))
            {
                SetActive(selectedTab.transform.GetSiblingIndex() + 1);
            }
        }
    }

    private void OnDisable()
    {
        SetActive(0);
    }

    public void StartActiveTab()
    {
        if (selectedTab == null)
        {
            SetActive(0);            
        }
    }
    
    public void SetActive(TabButton tabButton)
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
        for(int i = 0; i < tabButtons.Count; i++)
        {
            if (tabButtons[i].transform.GetSiblingIndex() == siblingIndex)    
            {
                SetActive(tabButtons[i]);
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
