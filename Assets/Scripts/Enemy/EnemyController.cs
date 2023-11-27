using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private FloatingHealthBar healthBar;

    private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    private float movementSpeed = 3.0f;
    private int range = 5;
    

    private float distance;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("LoseHealthOverTime", 1f, 1f);
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {        
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance > range)
        {
            Move();
        }

    }

    private void Move()
    {
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }

    void LoseHealthOverTime()
    {
        // Adjust the amount of health you want to lose per second
        int healthLossPerSecond = 10;

        // Ensure the character doesn't go below 0 health
        currentHealth = Mathf.Max(0, currentHealth - healthLossPerSecond);

        // Check if the character has run out of health
        if (currentHealth == 0)
        {
            Destroy(gameObject);
           
        }
    }
}
