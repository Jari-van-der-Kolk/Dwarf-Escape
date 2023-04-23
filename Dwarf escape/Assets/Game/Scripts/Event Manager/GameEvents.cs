using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
     public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action onBlockDestroyed;
    public void BlockDestroyed() 
    {
        if (onBlockDestroyed != null)
        {
            onBlockDestroyed();
        }
    }

    public event Action updateResourceValues;
    public void UpdateValues()
    {
        if (updateResourceValues != null)
        {
            updateResourceValues();
        }
    }

    
}
