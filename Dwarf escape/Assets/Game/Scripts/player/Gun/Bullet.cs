using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GunManager gunManager;
    public float deactivateCounter = 10f;

    private void OnEnable()
    {
        StartCoroutine(DeactivateTime(deactivateCounter));
    }

    private void OnDisable()
    {
        gunManager.pool.Release(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IHitable>().Hit(gunManager.bulletDamage);
            gunManager.pool.Release(gameObject);
        }
    }

    private IEnumerator DeactivateTime(float time)
    {
        yield return new WaitForSeconds(time);
        gunManager.pool.Release(gameObject);
    }
    
}
