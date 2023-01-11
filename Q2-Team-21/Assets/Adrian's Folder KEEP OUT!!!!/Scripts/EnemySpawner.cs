using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    public float spawnRadius = 10f;
    public float enemy1SpawnProbability = 0.6f;
    public float enemy2SpawnProbability = 0.3f;
    public float spawnInterval = 5f;
    public float minDistanceFromPlayer = 2f;
    public int currentWave;
    public List<GameObject> enemies;

    void Start()
    {
        // Start spawning enemies at the specified interval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Generate a random point within the spawn radius
        Vector3 randomPoint = transform.position + new Vector3(Random.insideUnitCircle.x, 0f, Random.insideUnitCircle.y) * spawnRadius;

        // Set the y coordinate of the random point to be the same as the player's y coordinate
        randomPoint.y = transform.position.y;

        // Make sure the point is at least minDistanceFromPlayer units away from the player
        Vector3 playerToPoint = randomPoint - transform.position;
        if (playerToPoint.magnitude < minDistanceFromPlayer)
        {
            randomPoint = transform.position + playerToPoint.normalized * minDistanceFromPlayer;
        }

        // Choose which enemy to spawn
        GameObject enemyPrefab = null;
        float randomValue = Random.value;
        if (randomValue < enemy1SpawnProbability)
        {
            enemyPrefab = enemy1Prefab;
        }
        else if (randomValue < enemy1SpawnProbability + enemy2SpawnProbability)
        {
            enemyPrefab = enemy2Prefab;
        }
        else
        {
            enemyPrefab = enemy3Prefab;
        }

        // Spawn the enemy
        Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
    }
}

