using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollsionOnContact : MonoBehaviour
{
    [SerializeField] private string tag;


    private void Start()
    {
        StartCoroutine(DeactivateTrigger()); 
    }

    IEnumerator DeactivateTrigger()
    {
        yield return new WaitForSeconds(.3f);
        GetComponent<Collider2D>().isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            gameObject.SetActive(false);
        }
    }

}
