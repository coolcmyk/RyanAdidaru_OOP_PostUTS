using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        // Manage wave timing and progression
        timer += Time.deltaTime;

        if (timer >= waveInterval && totalEnemies <= 0)
        {
            NextWave();
        }
    }

    private void StartWave()
    {
        // Reset timer and start spawning enemies for all spawners
        timer = 0;
        totalEnemies = 0;

        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.ResetSpawner();
            spawner.StartSpawning();
        }
    }

    private void NextWave()
    {
        // Increment wave number
        waveNumber++;

        // Start next wave
        StartWave();
    }

    public void OnEnemyDestroyed()
    {
        // Decrement total enemies when an enemy is destroyed
        totalEnemies--;

        // Optional: Check if wave is complete
        if (totalEnemies <= 0)
        {
            NextWave();
        }
    }
}