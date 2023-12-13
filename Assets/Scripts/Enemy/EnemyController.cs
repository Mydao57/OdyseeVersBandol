using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    protected FloatingHealthBar healthBar;
    [SerializeField] protected WeaponController weapon;
    protected int maxHealth = 100;
    [SerializeField] protected int currentHealth = 100;
    protected float movementSpeed = 3.0f;
    [SerializeField] protected float range = 0.8f;

    protected float distance;

    protected void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        distance = Vector2.Distance(player.transform.position, transform.position);

        FlipBasedOnDirection();

        if (distance > range)
        {
            Move();
            
        }
    }

    private void Move()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);

    }

    private void FlipBasedOnDirection()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Flip the character based on the direction
        if (direction.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
