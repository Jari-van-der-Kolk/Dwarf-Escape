using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SetPlayerLocation : MonoBehaviour
{
   private void Start()
   {
      Movement.instance.transform.position = transform.position;
   }
}
