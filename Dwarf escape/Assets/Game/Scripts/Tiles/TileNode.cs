using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode : MonoBehaviour, IHitable
{
    public TileNodeData tileNodeData;

    private SpriteRenderer _renderer;

    [SerializeField] private bool hasItem;
    private int durability;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        //_renderer.sprite = tileNodeData.defaultRockSprite;
        if (tileNodeData.property == null)
            hasItem = false;
        else
            hasItem = true;

        durability = tileNodeData.durability;
    }

    public void Hit(int hitAmount)
    {
        durability -= hitAmount;
        TileDestroyed();
    }

    private void TileDestroyed()
    {
        if (durability <= 0)
        {
            gameObject.SetActive(false);
        }
        if (hasItem)
        {
            Instantiate(tileNodeData.property);
        }
    }
    
}
