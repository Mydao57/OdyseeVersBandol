using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class WeaponShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float coins = 0;
    public Text coinsText;
    public ShopData shopData; 
    void Start()
    {
       

        coinsText.text = "Coins : " + coins.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        SaveLoadManager saveLoadManager = new SaveLoadManager();

        shopData = saveLoadManager.LoadPlayerData();

        coins = shopData.coins;
        coinsText.text = "Coins : " + coins.ToString();


    }

    void Update()
    {

       

     
    }

    public void BuyItem()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Vector3 weaponOffset = new Vector3(1f, 0f, 0f);

        if(coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemId])
        {



            GameObject player = GameObject.Find("Player");

            coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemId];
            coinsText.text = "Coins : " + coins.ToString();

            if (player.GetComponentInChildren<WeaponController>() != null)
            {
                Destroy(player.GetComponentInChildren<WeaponController>().gameObject);

            }

            WeaponController weapon = Instantiate(buttonRef.GetComponent<ButtonInfo>().weapon, player.transform);
            weapon.transform.position =  player.transform.position + weaponOffset;

            player.GetComponent<PlayerController>().EquipWeapon(weapon);

        }

    }

    public void CloseShop()
    {
        GameObject.Find("WeaponShop").SetActive(false);
    }

}
