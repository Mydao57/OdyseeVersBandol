using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; 
    public List<Transform> spawnPointsListLeft = new List<Transform>();
    public List<Transform> spawnPointsListRight = new List<Transform>(); 

    void Start()
    {
        SpawnRandomObstacles(spawnPointsListLeft, true);
        SpawnRandomObstacles(spawnPointsListRight, false); 
    }

    void SpawnRandomObstacles(List<Transform> spawnPoints, bool invertPrefab)
    {
        int numSpawnPointsToUse = Mathf.CeilToInt(spawnPoints.Count * 0.25f);

        List<int> selectedIndices = new List<int>();

        while (selectedIndices.Count < numSpawnPointsToUse)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);

            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (selectedIndices.Contains(i))
            {
                if (invertPrefab && spawnPoints == spawnPointsListLeft)
                {
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
