using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private WeaponController weapon;


    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        inputHandler();
    }

    void FixedUpdate()
    {
        
    }

    void inputHandler()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

   

    void Attack() 
    {if (weapon != null)
        {
            weapon.Attack(transform.right);
        }
    }


}
