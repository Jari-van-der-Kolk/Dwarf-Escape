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


    
}
