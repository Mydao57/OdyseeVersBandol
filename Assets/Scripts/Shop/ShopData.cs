using UnityEngine;

[System.Serializable]
public class ShopData
{
    public int coins;
    public int weaponID;

    public ShopData(int coins, int weaponID)
    {
        this.coins = coins;
        this.weaponID = weaponID;
    }
}

public class SaveLoadManager
{
    // Save player data
    public  void SavePlayerData(int coins, int weaponID)
    {
        ShopData shopdata = new ShopData(coins, weaponID);
        string jsonData = JsonUtility.ToJson(shopdata);
        PlayerPrefs.SetString("PlayerData", jsonData);
        PlayerPrefs.Save();
    }

    // Load player data
    public ShopData LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string jsonData = PlayerPrefs.GetString("PlayerData");
            ShopData shopdata = JsonUtility.FromJson<ShopData>(jsonData);
            return shopdata;
        }
        else
        {
            SavePlayerData(0, 0);
            return new ShopData(0, 0);
        }
    }

}
