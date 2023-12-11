using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : EnemyController
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (weapon.weaponCollider.IsTouching(player.GetComponent<Collider2D>()))
        {
            weapon.Attack();
        }
    }

}
