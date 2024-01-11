using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    SaveLoadManager saveLoadManager = new SaveLoadManager();
    public List<WeaponController> weapons;
    int weaponId = 0;
    void Start()
    {
        GameObject player = GameObject.Find("Player"); 

        weaponId = saveLoadManager.LoadPlayerData().weaponID;

        if(weaponId == 0)
        {
            weaponId = 1;
        }


        WeaponController weapon =  Instantiate(weapons[weaponId-1], transform.position, Quaternion.identity);
        
        switch (weaponId)
        {
            case 1:
                weapon.transform.position = player.transform.position + new Vector3(0.7f, -0.2f, 0f);
                break;
            case 2:
                weapon.transform.position = player.transform.position + new Vector3(0.5f, -0.1f, 0f);
                break;
            case 3:
                weapon.transform.position = player.transform.position + new Vector3(0.35f, -0.1f, 0f);
                break;
            case 4:
                weapon.transform.position = player.transform.position + new Vector3(0.5f, -0.11f, 0f);
                break;
        }


        weapon.transform.parent = player.transform;
        player.GetComponent<PlayerController>().EquipWeapon(weapon);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
