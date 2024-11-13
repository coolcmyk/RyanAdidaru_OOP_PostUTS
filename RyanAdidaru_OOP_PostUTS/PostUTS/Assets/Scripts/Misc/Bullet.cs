using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.Pool;



public class Bullet : MonoBehaviour 
{
    [Header("Bullet Stats")]
    
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;
    private IObjectPool<Bullet> pool;

    [SerializeField] bool isEnemy = false;

    void Awake()
    {
        isEnemy = false;
        if(gameObject.tag == "Enemy")
        {
            isEnemy = true;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isEnemy)
        {
            transform.position -= transform.up * bulletSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.up * bulletSpeed * Time.deltaTime;
        }
        // transform.position += transform.up * bulletSpeed * Time.deltaTime;
        CheckBoundaries();
    }

    private void CheckBoundaries()
    {
        if (transform.position.y >= 10f)
        {
            ReturnToPool();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        ReturnToPool();
    }

    public void SetPool(IObjectPool<Bullet> bulletPool)
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