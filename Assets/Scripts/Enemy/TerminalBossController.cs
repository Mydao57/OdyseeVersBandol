using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalBossController : EnemyController
{
    [SerializeField]
    private GameObject prefabTicket;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float currentCooldown;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0f ) {
            float attackNumber = UnityEngine.Random.Range(1, 4);

            switch (attackNumber)
            {
                case 1:
                    Attack1();
                    break;
                case 2: 
                    Attack2(); 
                    break;
                case 3:
                    Attack3(); 
                    break;
            }

            currentCooldown = cooldown;
        }


    }

    protected void Attack1()
    {
       StartCoroutine(throwTicket());
    }

    protected IEnumerator throwTicket()
    {
        
       
        for (int i = 0; i <= 2; i++)
        {
            GameObject ticket = Instantiate(prefabTicket);
            ticket.transform.position = this.transform.position;

            ticket.GetComponent<TicketBehaviour>().tag = tag;
            ticket.GetComponent<TicketBehaviour>().DirectionChecker(player.transform.position - this.transform.position);
            yield return new WaitForSeconds(0.2f);
        }
    }

    protected void Attack2()
    {
        Vector3 offset = new Vector3(0, 4);

        for(int i = 0; i <= 2; i++)
        {
            GameObject ticket = Instantiate(prefabTicket);
            ticket.transform.position = this.transform.position;
            ticket.GetComponent<TicketBehaviour>().tag = tag;
            if (i == 0)
            {
                ticket.GetComponent<TicketBehaviour>().DirectionChecker(player.transform.position + offset - this.transform.position);
            }
            else if (i == 1)
            {
                ticket.GetComponent<TicketBehaviour>().DirectionChecker(player.transform.position  - this.transform.position);

            }
            else if (i == 2)
            {
                ticket.GetComponent<TicketBehaviour>().DirectionChecker(player.transform.position - offset - this.transform.position);

            }
        }
            
    }

    protected void Attack3()
    {

        for (int i = 0; i <= 7; i++)
        {
            GameObject ticket = Instantiate(prefabTicket);
            ticket.transform.position = this.transform.position;

            ticket.GetComponent<TicketBehaviour>().tag = tag;

            float angle = i * 45f * Mathf.Deg2Rad;

            ticket.GetComponent<TicketBehaviour>().DirectionChecker(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f));
        }



    }


}
