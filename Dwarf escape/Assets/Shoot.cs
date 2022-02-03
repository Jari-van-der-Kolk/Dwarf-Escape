using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shoot : MonoBehaviour
{

    private ObjectPool<GameObject> pool;

    [SerializeField] private Transform shootPos;
    [SerializeField] private GameObject prefab;
    public float shootSpeed;
    public float bulletSpeed;
    private float timer;

    private void Start()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(prefab);
        }, bullet =>
        {
            bullet.SetActive(true);
            bullet.transform.position = shootPos.position;
            bullet.GetComponent<Rigidbody2D>().velocity = shootPos.right * bulletSpeed;
        }, bullet =>
        {
            bullet.SetActive(false);
        }, bullet =>
        {
            Destroy(bullet.gameObject);
        }, false, 30, 50);
    }


    private void Update()
    {
        timer += Time.deltaTime * shootSpeed;
        
        if (timer >= 1f && Input.GetMouseButtonDown(0) )
        { 
            pool.Get();
            timer = 0f;
        }
    }
}
