// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class HealthComponent : MonoBehaviour
// {
//     public int maxHealth { get; private set; }
//     public int _health;
    
//     public int health
//     {
//         get { return _health; }
//         private set { _health = Mathf.Clamp(value, 0, maxHealth); }
//     }

//     public void Initialize(int maxHealth)
//     {
//         this.maxHealth = maxHealth;
//         _health = maxHealth;
//     }

//     public void Subtract(int amount)
//     {
//         _health -= amount;
//         if (_health <= 0)
//         {
//             Destroy(gameObject);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public delegate void EnemyDestroyedHandler(GameObject DestroyedObject);
    public static event EnemyDestroyedHandler OnEnemyDestroyed;
    [SerializeField] public int _maxHealth;
    public int maxHealth
    {
        get { return _maxHealth; }
        private set { _maxHealth = value; }
    }

    private int _health;
    public int health
    {
        get { return _health; }
        private set { _health = Mathf.Clamp(value, 0, maxHealth); }
    }


    public int GetHealth()
    {
        return _health;
    }
    public void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        _health = maxHealth;
    }

    public void Subtract(int amount)
    {
        Debug.Log("Subtracting " + amount + " from " + _health);
        _health -= amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
            if (gameObject.tag == "Enemy")
            {
                OnEnemyDestroyed?.Invoke(gameObject);
            }
        }
    }

}
