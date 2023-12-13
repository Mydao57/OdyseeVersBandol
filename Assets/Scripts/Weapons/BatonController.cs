using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatonController : WeaponController
{
    private Animator animator;
    private GameObject player;

    private void Awake()
    {
        weaponCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
            currentCooldown = cooldownDuration;

            if (weaponCollider.IsTouching(player.GetComponent<Collider2D>()))
            {
                player.GetComponent<HealthManager>().TakeDamage(damage);
            }

        }
    }


  




}
