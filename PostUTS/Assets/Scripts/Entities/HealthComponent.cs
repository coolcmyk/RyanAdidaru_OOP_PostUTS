using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthComponent : MonoBehaviour
{
    public int maxHealth { get; private set; }
    private int _health;
    
    public int health
    {
        get { return _health; }
        private set { _health = Mathf.Clamp(value, 0, maxHealth); }
    }

    public void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        _health = maxHealth;
    }

    public void Subtract(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
