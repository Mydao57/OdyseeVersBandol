using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Le prefab de ton obstacle
    public List<Transform> spawnPointsListLeft = new List<Transform>(); // Premi�re liste de points de spawn
    public List<Transform> spawnPointsListRight = new List<Transform>(); // Deuxi�me liste de points de spawn

    void Start()
    {
        // Appelle la fonction de spawn au d�marrage pour chaque liste
        SpawnRandomObstacles(spawnPointsListLeft, true); // Utilise true pour indiquer la liste gauche
        SpawnRandomObstacles(spawnPointsListRight, false); // Utilise false pour indiquer la liste droite
    }

    void SpawnRandomObstacles(List<Transform> spawnPoints, bool invertPrefab)
    {
        // Calcul du nombre de spawn points � utiliser (25%)
        int numSpawnPointsToUse = Mathf.CeilToInt(spawnPoints.Count * 0.25f);

        // Cr�ation d'une liste temporaire pour stocker les indices des spawn points s�lectionn�s
        List<int> selectedIndices = new List<int>();

        // S�lection al�atoire de 25% des spawn points
        while (selectedIndices.Count < numSpawnPointsToUse)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);

            // V�rifie si l'indice n'est pas d�j� s�lectionn�
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }

        // Parcours tous les points de spawn
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            // V�rifie si l'indice fait partie des spawn points s�lectionn�s
            if (selectedIndices.Contains(i))
            {
                // Instancie l'obstacle uniquement sur les spawn points s�lectionn�s
                if (invertPrefab && spawnPoints == spawnPointsListLeft)
                {
                    // Inverse le prefab si le spawn point provient de la liste spawnPointsListLeft
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
                }
            }
        }
    }
}
