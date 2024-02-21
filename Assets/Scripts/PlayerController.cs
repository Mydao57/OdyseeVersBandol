using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private WeaponController weapon;
    private Text messageStat;
    [SerializeField]
    private Material blur;
    

    // Start is called before the first frame update
    void Start()
    {
        messageStat = GetComponentInChildren<Text>();
        if (blur)
        {
            blur.SetFloat("_BlurStrength", 0);

        }

    }

    void Update()
    {
        inputHandler();
    }

    void inputHandler()
    {
        if (Input.GetMouseButtonDown(0))
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
        if(item.alcohol != 0)
        {
            if (blur)
            {
                float currentBlurStrength = blur.GetFloat("_BlurStrength");
                float newBlurStrength = Mathf.Clamp(currentBlurStrength + item.alcohol, 0.0f, 5.0f);

                blur.SetFloat("_BlurStrength", newBlurStrength);
            }
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
        healthManager.damageTaken -= item.heal;
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
