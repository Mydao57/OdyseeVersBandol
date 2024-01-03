using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBehaviour : ProjectileWeaponBehaviour
{
    public ExplosiveController ec;
    

    protected override void Start()
    {
         ec = FindObjectOfType<ExplosiveController>();
         Invoke("Explode", ec.delay);
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ec.explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (collider.gameObject.tag != tag)
                {

                    if (collider.GetComponent<HealthManager>())
                    {
                        collider.GetComponent<HealthManager>().TakeDamage(ec.damage);
                    }
                    else if (collider.GetComponent<EnemyHealthManager>())
                    {
                       
                        collider.GetComponent<EnemyHealthManager>().TakeDamage(ec.damage);
                    }

                    Vector2 direction = (collider.transform.position - transform.position).normalized;
                    rb.AddForce(direction * ec.explosionForce, ForceMode2D.Impulse);
                }
               
            }
        }

        
        Destroy(gameObject);
    }

  




}
