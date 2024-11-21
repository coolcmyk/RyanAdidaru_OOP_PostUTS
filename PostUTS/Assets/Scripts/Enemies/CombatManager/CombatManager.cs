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
        timer += Time.deltaTime;

        if (timer >= waveInterval && totalEnemies <= 0)
        {
            NextWave();
        }
    }

    private void StartWave()
    {
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
        waveNumber++;
        StartWave();
    }

    public void OnEnemyDestroyed()
    {
        totalEnemies--;
        if (totalEnemies <= 0)
        {
            NextWave();
        }
    }
}