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

        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            hitbox.Damage(damage);
        }
    }
}
