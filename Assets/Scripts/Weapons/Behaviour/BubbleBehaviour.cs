using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : ProjectileWeaponBehaviour
{
    public WatergunController wc;
    public float stunTime = 0.5f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        wc = FindObjectOfType<WatergunController>();
    }

    private void Update()
    {
        transform.position += direction.normalized * wc.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag != tag)
        {

            if (other.GetComponent<HealthManager>())
            {
                other.GetComponent<HealthManager>().TakeDamage(wc.damage);
                Destroy(gameObject);

            }
            else if (other.GetComponent<EnemyHealthManager>())
            {

                other.GetComponent<EnemyHealthManager>().TakeDamage(wc.damage);
                StartCoroutine(Stun(other.gameObject));

            }
        }
        /*else
        {
            Destroy(gameObject);
        }*/

        return;
    }

    IEnumerator Stun(GameObject other)
    {
        EnemyController enemyController = other.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            float ms = enemyController.movementSpeed;

            enemyController.movementSpeed = 0;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false; 
            

            yield return new WaitForSeconds(stunTime);
            if(enemyController != null)
            {
                enemyController.movementSpeed = ms;
            }

        }
        Destroy(gameObject);

    }

}
