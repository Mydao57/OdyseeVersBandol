using UnityEngine;
using System.Collections.Generic;

public class TriggerZoneShop : MonoBehaviour
{

    public GameObject itemPrefab1;
    public GameObject itemPrefab2;
    public GameObject itemPrefab3;
    public GameObject itemPrefab4;
    public GameObject itemPrefab5;
    public GameObject itemPrefab6;
    public GameObject itemPrefab7;
    public GameObject itemPrefab8;
    public GameObject itemPrefab9;
    public GameObject itemPrefab10;
    public GameObject itemPrefab11;
    public GameObject itemPrefab12;
    public GameObject itemPrefab13;
    public GameObject itemPrefab14;
    public GameObject itemPrefab15;
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
            GenerateItem(); 
            triggerActivated = true;
            gameActive = true;
        }
    }

    void GenerateItem()
    {
            Transform spawnPoint = spawnPoints[0];

            GameObject selectedPrefab = GetRandomItemPrefab();

            Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
    }

    GameObject GetRandomItemPrefab()
    {
        List<GameObject> itemPrefabs = new List<GameObject>
        {
            itemPrefab1, itemPrefab2, itemPrefab3, itemPrefab4, itemPrefab5, itemPrefab6, itemPrefab7, itemPrefab8, itemPrefab9, itemPrefab10, itemPrefab11, itemPrefab12, itemPrefab13, itemPrefab14, itemPrefab15
        };

        int randomIndex = Random.Range(0, itemPrefabs.Count);
        return itemPrefabs[randomIndex];
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

    void Update()
    {
        if (gameActive && triggerActivated)
        {
            CheckForNoItem();
        }
    }

    void CheckForNoItem()
    {
        
            WallRight.SetActive(false);
        
    }
}