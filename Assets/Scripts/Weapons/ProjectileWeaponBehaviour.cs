using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 direction;
    public float destroyTime;
    public float damage;
    protected virtual void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered the trigger is the player
        other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        Destroy(gameObject);

    }
}
