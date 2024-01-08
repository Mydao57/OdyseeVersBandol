using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrainBehaviour : ProjectileWeaponBehaviour
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
            }
           

        }
        


        return;
    }


}
