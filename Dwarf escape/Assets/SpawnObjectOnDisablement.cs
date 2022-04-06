using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDisablement : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amount;
  
    private void OnDisable()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(prefab);
        }
    }
}
