using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjectOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);   
    }
}
