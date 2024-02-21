using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private WeaponController weapon;
    private Text messageStat;
    private float dashRange = 2f;
    private float dashCooldown = 2f;
    private bool canDash = true;
    public GameObject dashIndicatorYes;
    public GameObject dashIndicatorNo;

    void Start()
    {
        messageStat = GetComponentInChildren<Text>();
        UpdateDashIndicator();
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
            canDash = false;

            Vector3 dashDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

            transform.position += dashDirection * dashRange;

            StartCoroutine(ResetDashCooldown());
            UpdateDashIndicator();
    }

    IEnumerator ResetDashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
        UpdateDashIndicator();
    }

    void UpdateDashIndicator()
    {
        if (canDash)
        {
            dashIndicatorNo.SetActive(false);
            dashIndicatorYes.SetActive(true);
        }
        else
        {
            dashIndicatorYes.SetActive(false);
            dashIndicatorNo.SetActive(true);
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
