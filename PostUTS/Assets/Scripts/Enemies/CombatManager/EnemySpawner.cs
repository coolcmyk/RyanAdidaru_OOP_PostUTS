using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    private void Start()
    {
        spawnCount = defaultSpawnCount;
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (spawnedEnemy != null)
        {
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
            combatManager.totalEnemies++;
        }
    }

    public void OnEnemyKilled()
    {
        totalKill++;
        totalKillWave++;
        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            SpawnCountIncrease();
            totalKillWave = 0;
        }
    }

    private void SpawnCountIncrease()
    {
        spawnCountMultiplier += multiplierIncreaseCount;
        spawnCount = defaultSpawnCount * spawnCountMultiplier;
    }

    public void ResetSpawner()
    {
        totalKill = 0;
        totalKillWave = 0;
        spawnCount = defaultSpawnCount;
        spawnCountMultiplier = 1;
        isSpawning = false;
    }
}