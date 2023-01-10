using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int currentWave;
    public int remainingEnemies;
    public float spawnRadius;
    public List<GameObject> enemies;

    private void Start()
    {
        // Start the first wave
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        // Spawn the enemies for the current wave
        SpawnEnemies(currentWave);

        // Wait for all enemies to be destroyed
        while (remainingEnemies > 0)
        {
            yield return null;
        }

        // Increment the wave number
        currentWave++;

        // Spawn the next wave
        StartCoroutine(SpawnWave());
    }

    private void SpawnEnemies(int wave)
    {
        remainingEnemies = wave;
        for (int i = 0; i < wave; i++)
        {
            // randomly select an enemy from the list
            GameObject enemy = enemies[Random.Range(0, enemies.Count)];

            // Instantiate the enemy at a random point within the spawn radius
            Vector3 randomPoint = new Vector3(transform.position.x + UnityEngine.Random.Range(-spawnRadius, spawnRadius), 0, transform.position.z + UnityEngine.Random.Range(-spawnRadius, spawnRadius));
            Instantiate(enemy, randomPoint, Quaternion.identity);
        }
    }

    public void DecrementEnemyCount()
    {
        remainingEnemies--;
    }
}

