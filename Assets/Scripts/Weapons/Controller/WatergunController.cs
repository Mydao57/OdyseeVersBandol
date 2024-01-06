using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatergunController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        

    }

    // Update is called once per frame
    public override void Attack(Vector3? direction)
    {
        base.Attack(direction);
        if (currentCooldown <= 0f)
        {
            GameObject suitcase = Instantiate(prefab);

            suitcase.transform.position = transform.position;
            if (direction.HasValue)
            {
                suitcase.GetComponent<BubbleBehaviour>().DirectionChecker(direction.Value);
            }

            suitcase.GetComponent<BubbleBehaviour>().tag = tag;

            currentCooldown = cooldownDuration;

        }

    }
}
