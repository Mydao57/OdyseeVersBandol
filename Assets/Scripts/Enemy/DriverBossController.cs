using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DriverBossController : EnemyController
{
  
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float currentCooldown;
    protected override void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0f)
        {
            float attackNumber = Random.Range(1, 4);

            switch (attackNumber)
            {
                case 1:
                    Attack1();
                    break;
                case 2:
                    Attack2();
                    break;
                case 3:
                    Attack3();
                    break;
            }

            currentCooldown = cooldown;
        }


    }

    protected void Attack1()
    {
        float orientation = Random.Range(1, 5);
        Vector3 playerPosition = player.transform.position;
        switch (orientation)
        {
            case 1:
                Vector3 spawnPosition = new Vector3(playerPosition.x -10f, playerPosition.y, playerPosition.z);
                break;
        }


    }



    protected void Attack2()
    {
       

    }

    protected void Attack3()
    {




    }



}
