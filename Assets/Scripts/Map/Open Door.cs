using UnityEngine;
using System.Collections.Generic;

public class TriggerZone : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public int minTotalEnemies = 4;
    public int maxTotalEnemies = 10;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject WallLeft;
    public GameObject WallRight;

    private bool triggerActivated = false; // Variable de contrôle pour garder la trace de l'état du trigger
    private bool gameActive = false; // Variable pour suivre l'état du jeu

    void Start()
    {
        // Désactive les murs au départ
        SetWallsActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggerActivated && other.CompareTag("Player"))
        {
            // Le joueur est entré dans la TriggerZone pour la première fois, active les murs
            SetWallsActive(true);
            SpawnEnemies(); // Ajoutez cet appel ici pour activer les murs et spawner les ennemis
            triggerActivated = true; // Marque le trigger comme activé
            gameActive = true; // Active le jeu lorsque le joueur entre dans la TriggerZone
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
