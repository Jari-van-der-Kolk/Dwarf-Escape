using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHitable
{
    [SerializeField] private int currentHealth;
    
    
    public void Hit(int hitAmount)
    {
        currentHealth -= hitAmount;
        
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
