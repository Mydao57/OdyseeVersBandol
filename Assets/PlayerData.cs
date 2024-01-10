using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public InputField usernameInput;
    [SerializeField] private Canvas UsernameCanvas;
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
        else
        {
            UsernameCanvas.gameObject.SetActive(true);
        }

        PlayerDataJson playerData = new PlayerDataJson(username);

        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonData);

        Time.timeScale = 1f;

        UsernameCanvas.gameObject.SetActive(false);
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
                Time.timeScale = 1f;
            }
        }
        else
        {
            Invoke("Pause", 1.5f);
            UsernameCanvas.gameObject.SetActive(true);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
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
