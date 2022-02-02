using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JariUnityUISystem
{
    [System.Serializable]
    public class MenuNode
    {
        public KeyCode button;
        public GameObject panel;
        /*[HideInInspector]*/public bool activated;
        public int priority;
    }
}