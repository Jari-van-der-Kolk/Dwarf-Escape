using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode : MonoBehaviour, IHitable
{
    public TileNodeData tileNodeData;

    private SpriteRenderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        _renderer.sprite = tileNodeData.defaultRockSprite;
    }

    public void Hit()
    {
        Debug.Log("hit");
        _renderer.sprite = tileNodeData.propertySprite;
    }
}
