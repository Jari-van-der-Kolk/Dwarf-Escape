using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode : MonoBehaviour, IHitable
{
    public TileNodeData tileNodeData;

    private SpriteRenderer _renderer;

    private bool hasItem;
    private int durability;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        //_renderer.sprite = tileNodeData.defaultRockSprite;
        if (tileNodeData.SpawnPrefab == null)
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
            GameEvents.instance.BlockDestroyed();
            if (hasItem)
            {
                Instantiate(tileNodeData.SpawnPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            }
            
        }
    }
}
