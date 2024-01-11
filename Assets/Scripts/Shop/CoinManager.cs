using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    SaveLoadManager saveLoadManager = new SaveLoadManager();
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = saveLoadManager.LoadPlayerData().coins;
        Debug.Log("Coins: " + coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
