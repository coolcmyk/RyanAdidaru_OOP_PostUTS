
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour 
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;
    
    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    
    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;
    
    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    private float timer;
    
    public Transform parentTransform;
    private bool isEnemy;

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(    
            CreateBullet,        
            OnGetBullet,       
            OnReleaseBullet,   
            OnDestroyBullet,    
            collectionCheck,     
            defaultCapacity,     
            maxSize
        );
        isEnemy = gameObject.tag == "Enemy";
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Player.Instance.weaponState)
        {
            Debug.Log("has weapon");
            if (timer >= shootIntervalInSeconds)
            {
                Debug.Log("Shoot");
                SpawnBullet();
                timer = 0f;
            }
        }

        else if (isEnemy)
        {
            if (timer >= shootIntervalInSeconds)
            {
                Debug.Log("Shoot");
                SpawnBullet();
                timer = 0f;
            }
        }
    
    }

    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bullet);
        newBullet.SetPool(objectPool);
        return newBullet;
    }

    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
        if (parentTransform != null)
        {
            bullet.transform.parent = parentTransform;
        }
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void SpawnBullet()
    {
        objectPool.Get();
    }
}