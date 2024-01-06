using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        
        if (currentCooldown <= 0f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

    // Update is called once per frame
    public override void Attack(Vector3? direction)
    {
        base.Attack(direction);
        if (currentCooldown <= 0f)
        {
            GameObject suitcase = Instantiate(prefab);
            
            suitcase.transform.position = transform.position;
            if (direction.HasValue) {
                suitcase.GetComponent<SuitcaseBehaviour>().DirectionChecker(direction.Value);
            }
            
            suitcase.GetComponent<SuitcaseBehaviour>().tag = tag;

            currentCooldown = cooldownDuration;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }

    }
}
