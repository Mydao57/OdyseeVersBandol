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
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= weapon.radius)
        {
            Debug.Log("attackl");
            weapon.Attack(null);

        }
    }

}
