using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class WeaponShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public int coins = 0;
    public Text coinsText;
    SaveLoadManager saveLoadManager = new SaveLoadManager();

    void Start()
    {
        coins = saveLoadManager.LoadPlayerData().coins;

        coinsText.text = "Coins : " + coins.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;


    }

    void Update()
    {

       

     
    }

    public void BuyItem()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemId])
        {

            coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemId];
            coinsText.text = "Coins : " + coins.ToString();


            saveLoadManager.SavePlayerData(coins, buttonRef.GetComponent<ButtonInfo>().itemId);


        }

    }

    public void CloseShop()
    {
        GameObject.Find("WeaponShop").SetActive(false);
    }

}
