using UnityEngine;
using System.Collections.Generic;

public class TriggerZone : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject MiniBossPrefab1;
    public GameObject MiniBossPrefab2;
    public GameObject MiniBossPrefab3;
    public int minTotalEnemies = 4;
    public int maxTotalEnemies = 10;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject WallLeft;
    public GameObject WallRight;

    private bool triggerActivated = false;
    private bool gameActive = false;

    void Start()
    {
        SetWallsActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggerActivated && other.CompareTag("Player"))
        {
            SetWallsActive(true);
            SpawnEnemies();
            triggerActivated = true;
            gameActive = true;
        }
    }

    void ActivateMiniBoss()
    {
        GameObject selectedMiniBossPrefab = null;
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= (maxTotalEnemies + minTotalEnemies))
        {
            int miniBossIndex = Random.Range(0, 3);
            switch (miniBossIndex)
            {
                case 0:
                    selectedMiniBossPrefab = MiniBossPrefab1;
                    break;
                case 1:
                    selectedMiniBossPrefab = MiniBossPrefab2;
                    break;
                case 2:
                    selectedMiniBossPrefab = MiniBossPrefab3;
                    break;
            }

            if (selectedMiniBossPrefab != null)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                Instantiate(selectedMiniBossPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    void SetWallsActive(bool active)
    {
        if (WallLeft != null)
        {
            WallLeft.SetActive(active);
        }

        if (WallRight != null)
        {
            WallRight.SetActive(active);
        }
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

            Instantiate(selectedEnemyPrefab, spawnPosition, spawnPoint.rotation);
        }

        ActivateMiniBoss();
    }

    void Update()
    {
        if (gameActive && triggerActivated)
        {
            CheckForNoEnemies();
        }
    }

    void CheckForNoEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            WallRight.SetActive(false);
        }
    }
}