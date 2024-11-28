
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour 
{
    [Header("UI Text References")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemyCountText;

    private HealthComponent playerHealth;
    private EnemySpawner enemySpawner;
    private int points = 0;

    private void Start()
    {
        playerHealth = Player.Instance.GetComponent<HealthComponent>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
        HealthComponent.OnEnemyDestroyed += HandleEnemyDestroyed;
        
        UpdateAllUI();
    }

    private void OnDestroy()
    {
        HealthComponent.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }

    private void Update()
    {
        UpdateAllUI();
    }

    private void UpdateAllUI()
    {
        healthText.text = $"Health: {playerHealth?.health ?? 0}";
        pointsText.text = $"Points: {points}";
        
        if (enemySpawner != null)
        {
            waveText.text = $"Wave: {enemySpawner.combatManager.waveNumber}";
            enemyCountText.text = $"Enemies: {enemySpawner.spawnCount}";
        }
    }
    private void HandleEnemyDestroyed(GameObject destroyedObject)
    {
        Enemy enemy = destroyedObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            points += 10;
        }
    }
    
}

