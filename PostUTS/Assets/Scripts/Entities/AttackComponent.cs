using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab;
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(gameObject.tag))
        {
            return;
        }

        // HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        // if (hitbox != null)
        // {
        //     hitbox.Damage(damage);
        // }

        if (other.TryGetComponent<HitboxComponent>(out var hitbox))
        {
            if (other.TryGetComponent<InvincibilityComponent>(out var invincibilityComponent))
            {
                invincibilityComponent.StartInvincibility();
            }
            else
            {
                hitbox.Damage(damage);
            }
        }
    }

    public void DealDamage(GameObject target)
    {
        HitboxComponent hitbox = target.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            hitbox.Damage(damage);
        }
    }
}