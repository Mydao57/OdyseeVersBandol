using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnZone : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public int minTotalEnemies = 4;
    public int maxTotalEnemies = 10;

    public List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int numTotalEnemies = Random.Range(minTotalEnemies, maxTotalEnemies + 1);

        for (int i = 0; i < numTotalEnemies; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            GameObject selectedEnemyPrefab = (Random.value < 0.5f) ? enemyPrefab1 : enemyPrefab2;

            Vector3 randomOffset = Random.insideUnitCircle * 2f;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(randomOffset.x, 0f, randomOffset.y);

            Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
