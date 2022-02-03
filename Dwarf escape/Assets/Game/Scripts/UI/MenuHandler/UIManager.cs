using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JariUnityUISystem
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<MenuNode> menus;
        [SerializeField] private List<MenuNode> selectedMenus;
        private MenuNode lowestPriority;
        
        private void Awake()
        {
            AddLowestPriority();
            DeactivateAll();
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
            //hier check je of de node dat is aangedrukt al actief is of niet.
            if (menuNode.activated == true)
            {
                //checked of er een menuNode in selectedNodes niet al op stopActivity staat.
                //checked of de menuNode waar op gedrukt is niet zelf op stopActivity staat.
                if (StopActivity() == false || menuNode.stopActivity)
                {
                    //als dit zo is dan zet hij hem op inactive
                    Deactivate(menuNode);
                }
            }
            else if(menuNode.activated == false)
            {
               //als de aangedrukte node niet actief is dan zet je hem op active met deze functie.
                ActivateMenu(menuNode);
            }
        }

        private bool StopActivity()
        {
            //hij gaat door alles heen dat in de selectedMenus staat
            foreach (var s in selectedMenus)
            {
                //als er een van de selectedMenus een boolean heeft waar de stopActivity true op staat
                //zet hij de functie StopActivity op true
                if (s.stopActivity)
                {
                    return true;
                }
            }
            return false;
        }
        
        private void Deactivate(MenuNode menuNode)
        {
            menuNode.Deactivate();
            selectedMenus.Remove(menuNode);
        }
        
        private void ActivateMenu(MenuNode menuNode)
        {
            if (CheckPriority(menuNode) == false)
            {
                menuNode.Activate();
                selectedMenus.Add(menuNode);
            } 
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

        public void DeactivateAll()
        {
            foreach (var m in menus)
            {
                Deactivate(m);
            }
        }

        public void ChangeTime(float timeSpeed)
        {
            Time.timeScale = timeSpeed;
        }
    }
}
