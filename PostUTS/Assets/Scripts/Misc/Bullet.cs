using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.Pool;



public class Bullet : MonoBehaviour 
{
    [Header("Bullet Stats")]
    
    public float bulletSpeed = 20f;
    private Rigidbody2D rb;
    private IObjectPool<Bullet> pool;

    public int damage = 10;

    private Player player;
    [SerializeField] bool isEnemy;

    void Awake()
    {
        isEnemy = false;
        if(gameObject.tag == "Enemy")
        {
            isEnemy = true;
        }
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
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
        if (transform.position.y >= 5f)
        {
            ReturnToPool();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        player.weaponState = true;
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HitboxComponent>().Damage(damage);
            ReturnToPool();
        }
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
