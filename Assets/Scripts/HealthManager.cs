using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float damageTaken = 0f; 

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public SpriteRenderer player;
    private bool hasRotated = false;
    public PlayerMovement playerMovement;

    public AudioSource hit;
    public AudioSource death;

    void Start()
    {
        health = maxhealth;
        player = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        if( damageTaken == 6f)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = emptyHeart;
            }
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxhealth)
            {
                if (i == Mathf.FloorToInt(maxhealth - damageTaken))
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }

        if (health == 0f)
        {
            if (GameObject.Find("CoinManager").GetComponent<CoinManager>())
            {
                GameObject.Find("CoinManager").GetComponent<CoinManager>().SaveCoins();
            }


            if (!hasRotated)
            {

                death.Play();

                player.transform.Rotate(Vector3.forward * 90f);
                playerMovement.enabled = false;
                Invoke("SwitchScene", 1.5f);
                hasRotated = true;
            }

        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void TakeDamage(float damage)
    {
        damageTaken += damage;
        health -= damage;

        hit.Play();

        if (health < 0f)
        {
            health = 0f;
        }
    }
}
