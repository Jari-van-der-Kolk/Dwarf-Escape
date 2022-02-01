using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode : MonoBehaviour, IHitable
{
    public TileNodeData tileNodeData;

    private SpriteRenderer _renderer;

    [SerializeField] private bool hasItem;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
//        _renderer.sprite = tileNodeData.defaultRockSprite;
        if (tileNodeData.propertySprite == null)
            hasItem = false;
        else
            hasItem = true;
    }

    public void Hit()
    {
        Debug.Log("hit");
        if (hasItem)
        {
            _renderer.sprite = tileNodeData.propertySprite;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
