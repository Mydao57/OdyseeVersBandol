using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    SaveLoadManager saveLoadManager = new SaveLoadManager();
    int coins;
    int weaponId;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coins = saveLoadManager.LoadPlayerData().coins;
        weaponId = saveLoadManager.LoadPlayerData().weaponID;
        Debug.Log("Coins: " + coins);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text =  coins.ToString();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void SaveCoins()
    {
        saveLoadManager.SavePlayerData(coins, weaponId);
    }
}
