using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Inventory;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        var hit = Physics2D.CircleCast(playerTransform.position, radius, Vector2.up, 0, mask);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<IInteract>().Action();
        }
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
