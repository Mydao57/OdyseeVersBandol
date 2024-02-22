using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] private int score = 0;
    [SerializeField] protected WeaponController weapon = null;
    [SerializeField] public float movementSpeed = 3.0f;
    [SerializeField] protected float range;
    int coins = 2;
    public GameObject[] itemsToDrop;

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

    protected void Move()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);

    }

    protected void FlipBasedOnDirection()
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

    protected void OnDestroy()
    {
        GameObject scoreObject = GameObject.Find("Score");
        if (scoreObject != null)
        {
            ScoreManager scoreManager = scoreObject.GetComponent<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(score);
            }
        }

        GameObject coinManagerObject = GameObject.Find("CoinManager");
        if (coinManagerObject != null)
        {
            CoinManager coinManager = coinManagerObject.GetComponent<CoinManager>();
            if (coinManager != null)
            {
                coinManager.AddCoins(coins);
            }
        }

        if (itemsToDrop.Length > 0 && Random.value <= 1f)
        {
            int randomIndex = Random.Range(0, itemsToDrop.Length);
            GameObject randomItem = itemsToDrop[randomIndex];
            Instantiate(randomItem, transform.position, Quaternion.identity);
        }
    }

}
