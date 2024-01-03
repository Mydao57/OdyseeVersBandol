using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketBehaviour : ProjectileWeaponBehaviour
{
    public float speed;
    public float damage;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag != tag)
        {

            if (other.GetComponent<HealthManager>())
            {
                other.GetComponent<HealthManager>().TakeDamage(damage);
                Destroy(gameObject); 
            }
            else if (other.GetComponent<EnemyHealthManager>())
            {
                other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                Destroy(gameObject);
            }
            
        }

        return;
    }
}
