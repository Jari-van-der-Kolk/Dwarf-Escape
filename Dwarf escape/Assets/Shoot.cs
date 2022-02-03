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
    [SerializeField] private float shootSpeed;
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
            var bullet = pool.Get();
            bullet.GetComponent<Rigidbody2D>().velocity = transform.forward;
            timer = 0f;
        }
    }
}
