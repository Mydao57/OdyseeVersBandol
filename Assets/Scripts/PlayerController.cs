using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private WeaponController weapon;
    private Text messageStat;
    private float dashSpeed = 2f; // Vitesse de dash
    private float dashCooldown = 2f;
    private bool canDash = true; // Indique si le joueur peut dasher

    void Start()
    {
        messageStat = GetComponentInChildren<Text>();
    }

    void Update()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            Dash();
        }
    }

    void Dash()
    {
            // Désactive la possibilité de dasher
            canDash = false;

            // Enregistre la direction actuelle du joueur
            Vector3 dashDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

            // Effectue le dash
            transform.position += dashDirection * dashSpeed;

            // Lance une coroutine pour réactiver la possibilité de dasher après le cooldown
            StartCoroutine(ResetDashCooldown());
    }

    IEnumerator ResetDashCooldown()
    {
        // Attend le temps de cooldown du dash
        yield return new WaitForSeconds(dashCooldown);

        // Réactive la possibilité de dasher
        canDash = true;
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
