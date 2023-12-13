using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseBehaviour : ProjectileWeaponBehaviour
{
    public SuitcaseController sc;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        sc = FindObjectOfType<SuitcaseController>();
    }

    private void Update()
    {
        transform.position += direction.normalized * sc.speed * Time.deltaTime;
    }

   
}