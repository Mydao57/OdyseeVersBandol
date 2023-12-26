using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] protected WeaponController weapon = null;
    
    [SerializeField] protected float movementSpeed = 3.0f;
    [SerializeField] protected float range;

    protected float distance;

    protected void Awake()
    {
        player = GameObject.Find("Player");

    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player)
        {
            distance = Vector2.Distance(player.transform.position, transform.position);

            FlipBasedOnDirection();

            if (distance > range)
            {
                Move();

            }
        }
        
    }

    private void Move()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);

    }

    private void FlipBasedOnDirection()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Flip the character based on the direction
        if (direction.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
