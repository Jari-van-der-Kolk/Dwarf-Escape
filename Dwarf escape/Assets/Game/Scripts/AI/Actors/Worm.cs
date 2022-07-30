using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Enemy
{
    [SerializeField] LayerMask mask;

    void Update()
    {
        if (!HasObjectInSight(playerLocation, mask))
            return;
            
        GoToObject(playerLocation);
    }

}
