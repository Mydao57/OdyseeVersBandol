using UnityEngine;

public class WagonGenerator : MonoBehaviour
{
    /*public GameObject playerPrefab;*/
    public GameObject defaultZonePrefab;
    public GameObject linkZonePrefab;
    public GameObject shopZonePrefab;
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
        PositionZoneNextTo(defaultZone, linkZoneDefault, true);

        /*GeneratePlayerInZone(defaultZone);*/

        GameObject previousZone = linkZoneDefault;

        GameObject[] zonePrefabs = { zoneLvl2Prefab, zoneLvl3Prefab, zoneLvl4Prefab };

        for (int levelIndex = 0; levelIndex < zonePrefabs.Length; levelIndex++)
        {
            int randomCount = Random.Range(minZonesPerLevel, maxZonesPerLevel);

            for (int i = 0; i < randomCount; i++)
            {
                GameObject currentZone = InstantiateZone(zonePrefabs[levelIndex], 36f, grid);
                PositionZoneNextTo(previousZone, currentZone, true);
                previousZone = currentZone;
                GameObject linkZone = InstantiateZone(linkZonePrefab, 24f, grid);
                PositionZoneNextTo(previousZone, linkZone, true);
                previousZone = linkZone;

                if (i == randomCount - 1)
                {
                    GameObject shopZone = InstantiateZone(shopZonePrefab, 24f, grid);
                    PositionZoneNextTo(previousZone, shopZone, true);
                    previousZone = shopZone;
                    GameObject shopLinkZone = InstantiateZone(linkZonePrefab, 24f, grid);
                    PositionZoneNextTo(previousZone, shopLinkZone, false);
                    previousZone = shopLinkZone;
                }
            }

            // Incrémentez le compteur pour le niveau actuel
        }


        GameObject bossZone = InstantiateZone(bossZonePrefab, 36f, grid);
        PositionZoneNextTo(previousZone, bossZone, true);
    }

    GameObject InstantiateZone(GameObject zonePrefab, float width, Transform parent)
    {
        GameObject zone = Instantiate(zonePrefab, Vector3.zero, Quaternion.identity, parent);
        zone.transform.localScale = new Vector3(1f, 1f, 1f);
        return zone;
    }

    void PositionZoneNextTo(GameObject referenceZone, GameObject zone, bool type)
    {
        if (type)
        {
            float xOffset = referenceZone.transform.position.x + (referenceZone.transform.localScale.x * 36f) / 2f + (zone.transform.localScale.x * 36f) / 2f - 6f;
            zone.transform.position = new Vector3(xOffset, 0f, 0f);
        }
        else
        {
            float xOffset = referenceZone.transform.position.x + (referenceZone.transform.localScale.x * 36f) / 2f + (zone.transform.localScale.x * 36f) / 2f - 12f;
            zone.transform.position = new Vector3(xOffset, 0f, 0f);
        }
    }

    /* void GeneratePlayerInZone(GameObject zone)
     {
         GameObject player = Instantiate(playerPrefab, zone.transform.position, Quaternion.identity);
     }*/
}