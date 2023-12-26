using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    protected float maxHealth;
    [SerializeField] protected float currentHealth;
    [SerializeField] public FloatingHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);

        }

    }
}
