using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveController : WeaponController
{
    [SerializeField]
    public float throwForce;
    public float explosionRadius;
    public float explosionForce;
    public float delay;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (currentCooldown <= 0f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    // Update is called once per frame
    public override void Attack(Vector3? direction)
    {
        base.Attack(direction);
        if (currentCooldown <= 0f)
        {
            GameObject explosive = Instantiate(prefab);
            explosive.transform.position = transform.position;
            if (direction.HasValue)
            {
                explosive.GetComponent<Rigidbody2D>().AddForce(direction.Value * throwForce, ForceMode2D.Impulse);

            }
            explosive.GetComponent<ExplosiveBehaviour>().tag = tag;
            currentCooldown = cooldownDuration;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }

    }
    
}