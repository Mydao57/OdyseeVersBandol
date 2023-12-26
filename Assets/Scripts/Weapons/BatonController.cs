using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatonController : WeaponController
{
    private Animator animator;

    public override void Attack(Vector3? direction)
    {
        base.Attack(direction);
        animator = GetComponent<Animator>();
       

        if (currentCooldown <= 0f)
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");

            }

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            currentCooldown = cooldownDuration;


            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    if (collider.GetComponent<HealthManager>() && tag != "Player")
                    {
                        collider.GetComponent<HealthManager>().TakeDamage(damage);
                    }
                    else if (collider.GetComponent<EnemyHealthManager>() && tag != "Enemy")
                    {

                        collider.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                    }
                } 
               
            }


        }
    }








}
