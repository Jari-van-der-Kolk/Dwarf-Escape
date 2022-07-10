using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InitializeManagers : MonoBehaviour
{


    void Start()
    {
        var mangers = FindObjectsOfType<MonoBehaviour>().OfType<IManager>().ToArray();
        Debug.Log(mangers.Length);  
        for (int i = 0; i < mangers.Length; i++)
        {
            mangers[i].Init();
            Debug.Log(mangers[i]);
        }
    }

   
}
