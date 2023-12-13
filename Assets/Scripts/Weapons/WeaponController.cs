using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public Collider2D weaponCollider;   
    public float damage;
    public float speed;
    public float cooldownDuration;
    public float currentCooldown;
    public int pierce;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
      currentCooldown -= Time.deltaTime;
    }

    public virtual void Attack()
    {
    }
    public virtual void Attack(Vector3 direction)
    {
    }


}
