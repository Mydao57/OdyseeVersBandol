using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatonController : WeaponController
{
    private Animator animator;

    private void Awake()
    {
        weaponCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        base.Attack();
        if (currentCooldown <= 0f)
        {
            Debug.Log("Attack");

            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
            currentCooldown = cooldownDuration;

        }

    }
}
