using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public WeaponController weapon;
    public int itemId;
    public Text priceText;
    public GameObject ShopManager;
 
     void Update()
    {
       
        priceText.text = "Prix :" + ShopManager.GetComponent<WeaponShopManagerScript>().shopItems[2, itemId].ToString();
    }
}
