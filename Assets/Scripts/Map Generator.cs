using UnityEngine;

public class WagonGenerator : MonoBehaviour
{
    public GameObject defaultZonePrefab;
    public GameObject linkZonePrefab;
    public GameObject zoneLvl2Prefab;
    public GameObject zoneLvl3Prefab;
    public GameObject zoneLvl4Prefab;
    public GameObject bossZonePrefab;

    public int minZonesPerLevel = 1;
    public int maxZonesPerLevel = 5;

    public Transform grid;

    void Start()
    {
        GenerateWagon();
    }

    void GenerateWagon()
    {
        GameObject defaultZone = InstantiateZone(defaultZonePrefab, 36f, grid);

        GameObject linkZoneDefault = InstantiateZone(linkZonePrefab, 24f, grid);
        PositionZoneNextTo(defaultZone, linkZoneDefault);

        GameObject previousZone = linkZoneDefault;

        // Liste des prefabs de zones (à l'exception de default, boss et link)
        GameObject[] zonePrefabs = { zoneLvl2Prefab, zoneLvl3Prefab, zoneLvl4Prefab };

        foreach (GameObject zonePrefab in zonePrefabs)
        {
            // Génère entre 1 et 5 fois la zone en question
            int randomCount = Random.Range(minZonesPerLevel, maxZonesPerLevel);

            for (int i = 0; i < randomCount; i++)
            {
                GameObject currentZone = InstantiateZone(zonePrefab, 36f, grid);
                PositionZoneNextTo(previousZone, currentZone);
                previousZone = currentZone;
                GameObject linkZone = InstantiateZone(linkZonePrefab, 24f, grid);
                PositionZoneNextTo(previousZone, linkZone);
                previousZone = linkZone;
            }
        }

        // Ajoute la boss zone à la fin
        GameObject bossZone = InstantiateZone(bossZonePrefab, 36f, grid);
        PositionZoneNextTo(previousZone, bossZone);
    }

    GameObject InstantiateZone(GameObject zonePrefab, float width, Transform parent)
    {
        GameObject zone = Instantiate(zonePrefab, Vector3.zero, Quaternion.identity, parent);
        zone.transform.localScale = new Vector3(1f, 1f, 1f);
        return zone;
    }

    void PositionZoneNextTo(GameObject referenceZone, GameObject zone)
    {
        float xOffset = referenceZone.transform.position.x + (referenceZone.transform.localScale.x * 36f) / 2f + (zone.transform.localScale.x * 36f) / 2f -6f;
        zone.transform.position = new Vector3(xOffset, 0f, 0f);
    }
}
