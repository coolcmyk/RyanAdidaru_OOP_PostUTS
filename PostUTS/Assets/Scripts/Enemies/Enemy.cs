using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [Header("Enemy Stats")]
    [SerializeField] private int level = 1;
    [SerializeField] private float baseHealth = 100f;
    [SerializeField] private float baseDamage = 10f;
    
    private float currentHealth;
    private float currentDamage;

    public void Start()
    {
        if (GameManager.Instance != null)
        {
            SetEnemyLevel(GameManager.Instance.LevelManager.GetCurrentLevel());
        }
        
        InitializeStats();
    }

    public void SetEnemyLevel(int newLevel)
    {
        level = newLevel;
        InitializeStats();
    }


    //ini relatif terhadap level
    private void InitializeStats()
    {
        currentHealth = baseHealth + (baseHealth * 0.1f * (level - 1));
        currentDamage = baseDamage + (baseDamage * 0.1f * (level - 1));
    }

    public int GetLevel()
    {
        return level;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetCurrentDamage()
    {
        return currentDamage;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}