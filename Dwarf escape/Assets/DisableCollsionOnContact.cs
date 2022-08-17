using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollsionOnContact : MonoBehaviour
{
    [SerializeField] private string tag;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("gf");
        if (collision.collider.CompareTag(tag))
        {
            gameObject.SetActive(false);
        }
        
    }

}
