using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public InputField usernameInput;

    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/data.json";
        LoadUsername();
    }

    public void SaveUsername()
    {
        string username = usernameInput.text;

        if (File.Exists(filePath))
        {
        
        string existingData = File.ReadAllText(filePath);
            PlayerDataJson existingPlayerData = JsonUtility.FromJson<PlayerDataJson>(existingData);

            if (existingPlayerData != null && existingPlayerData.username == username)
            {
                Debug.Log("Nom d'utilisateur déjà saisi : " + username);
                return;
            }
        }

        PlayerDataJson playerData = new PlayerDataJson(username);

        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonData);

    }

    private void LoadUsername()
    {
        if (File.Exists(filePath))
        {
            string existingData = File.ReadAllText(filePath);
            PlayerDataJson existingPlayerData = JsonUtility.FromJson<PlayerDataJson>(existingData);

            if (existingPlayerData != null)
            {
                usernameInput.text = existingPlayerData.username;
            }
        }
    }
}

[System.Serializable]
public class PlayerDataJson
{
    public string username;

    public PlayerDataJson(string username)
    {
        this.username = username;
    }
}

