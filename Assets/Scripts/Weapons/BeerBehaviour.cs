using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerBehaviour : ProjectileWeaponBehaviour
{
    public BeerController bc;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bc = FindObjectOfType<BeerController>();
    }

    private void Update()
    {
        transform.position += direction.normalized * bc.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != tag)
        {

            if (other.GetComponent<HealthManager>())
            {
                other.GetComponent<HealthManager>().TakeDamage(bc.damage);
            }
            else if (other.GetComponent<EnemyHealthManager>())
            {
                other.GetComponent<EnemyHealthManager>().TakeDamage(bc.damage);
            }
            Destroy(gameObject);
        }

        return;
    }
}
