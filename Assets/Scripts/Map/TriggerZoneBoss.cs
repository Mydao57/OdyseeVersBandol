using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using System;

public class TriggerZoneBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject WallLeft;

    public ScoreManager scoreManager;

    private bool triggerActivated = false;
    private bool gameActive = false;

    private string filePath;
    private PlayerDataJson existingPlayerData;

    private string serverURL = "http://mydao.fr:5000";

    private bool hasSended = false;

    void Start()
    {
        SetWallsActive(false);

        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();

        filePath = Application.persistentDataPath + "/data.json";
        string existingData = File.ReadAllText(filePath);
        existingPlayerData = JsonUtility.FromJson<PlayerDataJson>(existingData);
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
                GameObject.Find("CoinManager").GetComponent<CoinManager>().SaveCoins();
            }
            
            if (!hasSended)
            {
                string url = $"mydao.fr:5000/Score?name={existingPlayerData.username}&score={scoreManager.scoreValue}";

                UnityWebRequest www = UnityWebRequest.Get(url);
                www.SendWebRequest();
                hasSended = true;
                
            }
            SceneManager.LoadScene("EndGame");

        }

    }
}
