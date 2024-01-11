using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private WeaponController weapon;
    private Text messageStat;

    

    // Start is called before the first frame update
    void Start()
    {
        messageStat = GetComponentInChildren<Text>();
    }

    void Update()
    {
        inputHandler();
    }

    void inputHandler()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Attack();
        }
    }

    void Attack() 
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0; 

        Vector3 playerPosition = transform.position;

        Vector3 directionToMouse = mouseWorldPosition - playerPosition;

    
        directionToMouse.Normalize();

        if (weapon != null)
        {
            weapon.Attack(directionToMouse);
        }
    }

    public void EquipWeapon(WeaponController weapon)
    {
        this.weapon = weapon;
    }

    public void PickItem(ItemController item)
    {
        
        if(item.movementSpeed > 0)
        {
            GetComponent<PlayerMovement>().moveSpeed += item.movementSpeed;
            messageStat.text += "\n+ Vitesse de déplacement";
        }
        
        if (weapon != null)
        {
            if (item.damage > 0)
            {
                weapon.damage += item.damage;
                messageStat.text += "\n+ Dégats";
            }
            if (item.cooldoownReduction > 0)
            {
                weapon.cooldownDuration -= weapon.cooldownDuration * item.cooldoownReduction;
                messageStat.text += "\n+ Vitesse d'attaque";
            }
        }
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        healthManager.health += item.heal;
        if(healthManager.health > healthManager.maxhealth)
        {
            healthManager.health = healthManager.maxhealth;
        }

        Invoke("ClearMessage", 2f);
    }


    void ClearMessage()
    {
        if (messageStat != null)
        {
            messageStat.text = "";
        }
    }
}
