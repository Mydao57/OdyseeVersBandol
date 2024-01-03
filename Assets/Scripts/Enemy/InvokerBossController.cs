using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerBossController : EnemyController
{

    [SerializeField] private GameObject[] enemiesToSpawn;
    [SerializeField] private float spawnCooldown;
    [SerializeField]
    private float currentSpawnCooldown;
    private Boolean noInvocations = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentSpawnCooldown = 0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            noInvocations = true;
        }
        else
        {
            noInvocations = false;
        }
        base.Update();
        Attack();
    }


    protected void Attack()
    {
        if (noInvocations && currentSpawnCooldown <= 0f)
        {
                
                for (int i = 0; i < enemiesToSpawn.Length; i++)
                {
                    float angle = i * (360f / enemiesToSpawn.Length) * Mathf.Deg2Rad;

                    float spawnRadius = 2.0f; 
                    Vector3 spawnPosition = new Vector3(
                        transform.position.x + spawnRadius * Mathf.Cos(angle),
                        transform.position.y + spawnRadius * Mathf.Sin(angle),
                        transform.position.z
                    );

                    GameObject enemy = Instantiate(enemiesToSpawn[i], spawnPosition, Quaternion.identity);
                }
                currentSpawnCooldown = spawnCooldown;
        
        }
        else if (noInvocations)
        { 
            currentSpawnCooldown -= Time.deltaTime;
        }
    }
}
