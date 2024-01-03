using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseBossController : EnemyController
{
    
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float currentCooldown;
    private bool move = false;
    private bool damage = true;
    private bool attacking = false;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if(!attacking)
        {
            currentCooldown -= Time.deltaTime;

        }

        if (move)
        {
            Move();
        }

        if (currentCooldown <= 0f)
        {
            float attackNumber = UnityEngine.Random.Range(1, 3);
            damage = true;
                switch (attackNumber)
                {
                    case 1:
                        Attack1();
                        break;
                    case 2:
                        Attack2();
                        break;
                    case 3:
                        break;
                }

                currentCooldown = cooldown;
            
           
        }


    }

    private void Attack1()
    {
        StartCoroutine(DashToPlayer());
    }

    

    private IEnumerator DashToPlayer()
    {
        // play animation 
        attacking = true;

        yield return new WaitForSeconds(2f);

        Vector3 startPosition = transform.position;

        Vector3 targetPosition = player.transform.position; 

        float duration = 0.5f; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

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
        attacking = false;
    }

    private void Attack2()
    {
        StartCoroutine(followPlayer());
    }

    private IEnumerator followPlayer()
    {
        attacking = true;
        move = true;

        yield return new WaitForSeconds(5f);

        attacking = false;
        move = false;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<HealthManager>() != null)
        {
            if(damage == true)
            {
                collision.GetComponentInParent<HealthManager>().TakeDamage(1);
                damage = false;
            }

        }
    }

}
