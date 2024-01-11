using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    SaveLoadManager saveLoadManager = new SaveLoadManager();
    public Text coinTxt;
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = saveLoadManager.LoadPlayerData().coins;
    }

    public void addCoin(int coin)
    {
        coins += coin;
    }

    public void saveCoins()
    {
        saveLoadManager.SavePlayerData(coins, 0);
    }

    // Update is called once per frame
    void Update()
    {
        coinTxt.text =  coins.ToString();
    }
}
