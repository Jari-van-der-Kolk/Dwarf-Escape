using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PerlinMapGenerator))]
public class BeginAndEndGenerator : MonoBehaviour
{
    private PerlinMapGenerator _perlinMapGenerator;

    [SerializeField] private GameObject beginPrefab;
    [SerializeField] private GameObject endPrefab;

    private void Awake()
    {
        _perlinMapGenerator = GetComponent<PerlinMapGenerator>();
    }
    private void Start()
    {
        
    }
    
    
    
    
}
