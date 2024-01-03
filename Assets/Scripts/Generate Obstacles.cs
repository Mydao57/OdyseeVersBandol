using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Le prefab de ton obstacle
    public List<Transform> spawnPoints = new List<Transform>(); // Liste des points de spawn

    void Start()
    {
        // Appelle la fonction de spawn au démarrage
        SpawnRandomObstacles();
    }

    void SpawnRandomObstacles()
    {
        // Calcul du nombre de spawn points à utiliser (25%)
        int numSpawnPointsToUse = Mathf.CeilToInt(spawnPoints.Count * 0.25f);

        // Création d'une liste temporaire pour stocker les indices des spawn points sélectionnés
        List<int> selectedIndices = new List<int>();

        // Sélection aléatoire de 25% des spawn points
        while (selectedIndices.Count < numSpawnPointsToUse)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);

            // Vérifie si l'indice n'est pas déjà sélectionné
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }

        // Parcours tous les points de spawn
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            // Vérifie si l'indice fait partie des spawn points sélectionnés
            if (selectedIndices.Contains(i))
            {
                // Instancie l'obstacle uniquement sur les spawn points sélectionnés
                Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
