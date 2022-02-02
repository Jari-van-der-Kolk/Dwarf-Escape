using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JariUnityUISystem
{
    public class UIManager : MonoBehaviour
    {
        enum MenuState
        {
            Idle,
            Active,
            Deactivated
        };

        //zorg ervoor dat je makkelijk keys kunt assignen in de inspector.
        //zorg ervoor dat ze niet allebei tegenlijk aan kunnen gaan.
        //maak een priority list waar als een met een hogere priority aanstaat, de andere niet aan kan.
        
        [SerializeField] private MenuState menuState;
        
        [SerializeField] private List<MenuNode> menus;
        [SerializeField] private List<MenuNode> selectedMenus;
        private MenuNode lowestPriority;
        
        private void Awake()
        {
            AddLowestPriority();
        }


        private void Update()
        {
            foreach (var m in menus)
            {
                if (Input.GetKeyDown(m.button))
                {
                    HandleMenu(m);
                }
            }
        }


        private void HandleMenu(MenuNode menuNode)
        {
            if (CheckPriority(menuNode))
            {
                selectedMenus.Add(menuNode);
            } 
           
        }

        private void Deactivate(MenuNode menuNode)
        {
            menuNode.activated = false;
            selectedMenus.Remove(menuNode);
        }


        private bool CheckPriority(MenuNode menuNode)
        {
            for (int i = 0; i < selectedMenus.Count; i++)
            {
                if (menuNode.priority < selectedMenus[i].priority)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddLowestPriority()
        {
            MenuNode lowestPriority = new MenuNode();
            lowestPriority.priority = int.MinValue;
            selectedMenus.Add(lowestPriority);
        }
    }
}


/*
        private bool skip;
        
        private void Start()
        {
            menuState = MenuState.Idle;
            skip = false;
        }

       
        private void LateUpdate()
        {
            if (menuState == MenuState.Idle && AnyActive() == false && skip == false)
            {
                foreach (var m in menus)
                {
                    if (Input.GetKeyDown(m.button))
                    {
                        m.activated = true;
                        selectedMenus.Add(m);
                        menuState = MenuState.Active;
                    }
                }
            }
            skip = false;
        }

        private void Update()
        {
            if (menuState == MenuState.Active)
            {
                foreach (var s in selectedMenus)
                {
                    if (Input.GetKeyDown(s.button))
                    {
                        Debug.Log("bruh");
                        s.activated = false;
                        menuState = MenuState.Idle;
                        skip = true;
                        selectedMenus.Remove(s);
                    }
                }
              
             
            }
        }
        
        private bool AnyActive()
        {
            for (int i = 0; i < menus.Count; i++)
            {
                if (menus[i].activated == true)
                {
                    Debug.Log("fuck you");
                    return true;
                }
            }

            return false;
        }
        */