using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))] 
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health;
    public void Damage(Bullet bullet)
    {
        if (health != null)
        {
            health.Subtract(bullet.damage);
        }
    }
    public void Damage(int damageAmount)
    {
        if (health != null)
        {
            health.Subtract(damageAmount);
        }
    }
}
