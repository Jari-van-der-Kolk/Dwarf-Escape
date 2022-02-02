using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //TODO make sure this will not be sphagetti code
    
    
    [SerializeField] private GameObject craftingMenu;
    [SerializeField] private GameObject pauseMenu;

    private bool isCraftingMenuActive;
    private bool isPauseMenuActive;

    private void Start()
    {
        isCraftingMenuActive = false;
        isPauseMenuActive = false;
        
        craftingMenu.SetActive(isCraftingMenuActive);
        pauseMenu.SetActive(isPauseMenuActive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCraftingMenuActive = !isCraftingMenuActive;
            craftingMenu.SetActive(isCraftingMenuActive);
        }
    }
}
