using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GunManager : MonoBehaviour
{
    
    
    
    public ObjectPool<GameObject> pool;
    private List<Bullet> bullets;

    [SerializeField] private Transform shootPos;
    [SerializeField] private GameObject prefab;
    public float shootSpeed;
    public float bulletSpeed;
    public int bulletDamage;

    private float timer;

    private void Start()
    {
        pool = new ObjectPool<GameObject>(CreateBullet, bullet =>
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

    public void Subscribe(Bullet bullet)
    {
        if (bullets == null)
        {
            bullets = new List<Bullet>();
        }

        bullets.Add(bullet);
    }

    private GameObject CreateBullet()
    {
        GameObject bulletObject = Instantiate(prefab);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.gunManager = this;
        Subscribe(bullet);
        return bulletObject;
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
