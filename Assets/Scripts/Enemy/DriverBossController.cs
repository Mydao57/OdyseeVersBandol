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
    [SerializeField]
    GameObject trainPrefab;
    protected override void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0f)
        {
            float attackNumber = Random.Range(1, 2);

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
        GameObject train = Instantiate(trainPrefab);

        train.transform.position = new Vector3(player.transform.position.x -10f, player.transform.position.y, player.transform.position.z);

        train.tag = tag;
        train.GetComponent<GhostTrainBehaviour>().tag = tag;



       train.GetComponent<GhostTrainBehaviour>().DirectionChecker(player.transform.position - train.transform.position); ;


    }



    protected void Attack2()
    {
       

    }

    protected void Attack3()
    {




    }



}
