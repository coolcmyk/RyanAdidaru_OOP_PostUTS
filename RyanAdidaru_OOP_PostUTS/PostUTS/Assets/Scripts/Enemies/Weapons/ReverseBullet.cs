using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.Pool;


public class ReverseBullet : MonoBehaviour 
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;
    private IObjectPool<ReverseBullet> pool;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position -= transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ReturnToPool();
    }

    void OnBecameInvisible()
    {
        ReturnToPool();
    }

    public void SetPool(IObjectPool<ReverseBullet> bulletPool)
    {
        pool = bulletPool;
    }

    private void ReturnToPool()
    {
        if (pool != null)
        {
            pool.Release(this);
        }
    }
}