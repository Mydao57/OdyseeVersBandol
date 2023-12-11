using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 direction;
    public float destroyTime;
    protected virtual void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }
}
