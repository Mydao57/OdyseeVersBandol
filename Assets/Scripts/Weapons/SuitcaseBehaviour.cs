using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseBehaviour : ProjectileWeaponBehaviour
{
    public SuitcaseController sc;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        sc = FindObjectOfType<SuitcaseController>();
    }

    private void Update()
    {
        transform.position += direction.normalized * sc.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag != tag)
        {

            if (other.GetComponent<HealthManager>())
            {
                other.GetComponent<HealthManager>().TakeDamage(sc.damage);
                Destroy(gameObject);

            }
            else if (other.GetComponent<EnemyHealthManager>())
            {
                other.GetComponent<EnemyHealthManager>().TakeDamage(sc.damage);
                Destroy(gameObject);

            }
        }

        return;
    }


   }