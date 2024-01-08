using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MecaBossController : EnemyController
{
  
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float currentCooldown;
    [SerializeField]
    private GameObject trainPrefab;
    [SerializeField]
    private GameObject energyBallPrefab;

    private bool move = true;

    Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (move)
        {
            currentCooldown -= Time.deltaTime;
            animator.SetBool("move", true);
            Move();
        }
        else
        {
            animator.SetBool("move", false);
        }

        FlipBasedOnDirection();




        if (currentCooldown <= 0f)
        {
            float attackNumber = Random.Range(1,4) ;

            switch (attackNumber)
            {
                case 1:
                    move = false;
                    animator.SetTrigger("Invoke");
                    break;
                case 2:
                    move = false;
                    animator.SetTrigger("Energy");
                    break;
                case 3:
                    move = false;
                    animator.SetTrigger("Charge");
                    break;
            }

            currentCooldown = cooldown;
        }


    }

    public void Attack1()
    {
        GameObject train = Instantiate(trainPrefab);

        train.transform.position = new Vector3(player.transform.position.x -15f, player.transform.position.y, player.transform.position.z);

        train.tag = tag;
        train.GetComponent<GhostTrainBehaviour>().tag = tag;

        train.GetComponent<GhostTrainBehaviour>().DirectionChecker(player.transform.position - train.transform.position); ;
        move = true;

    }



    protected void Attack2()
    {

        GameObject energyBall = Instantiate(energyBallPrefab);

        energyBall.transform.position = transform.position;

        energyBall.tag = tag;
        energyBall.GetComponent<EnergyBallBehaviour>().tag = tag;

        energyBall.GetComponent<EnergyBallBehaviour>().DirectionChecker(player.transform.position - this.transform.position); ;
        move = true;
    }

    protected void Attack3()
    {
        
        StartCoroutine(Charge());


        

        move = true;


    }

    IEnumerator Charge()
    {
        float dashTime = 1f;

        Vector3 originalPosition = transform.position;
        Vector3 dashDestination = player.transform.position;

        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            transform.position = Vector3.Lerp(originalPosition, dashDestination, elapsedTime / dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = dashDestination;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                HealthManager playerHealth = collider.GetComponent<HealthManager>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1);
                }

            }
        }
    }

}
