using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TriggerZoneBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject WallLeft;

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
            ActivateMiniBoss(); // Appel de la fonction pour faire apparaître le boss
            triggerActivated = true;
            gameActive = true;
        }
    }

    void ActivateMiniBoss()
    {
            Instantiate(bossPrefab, spawnPoints[0].position, Quaternion.Euler(0f, 180f, 0f));
    }


    void SetWallsActive(bool active)
    {
        if (WallLeft != null)
        {
            WallLeft.SetActive(active);
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
            if (GameObject.Find("CoinManager").GetComponent<CoinManager>())
            {
                GameObject.Find("CoinManager").GetComponent<CoinManager>().saveCoins();
            }
            SceneManager.LoadScene("EndGame");
        }
    }
}
