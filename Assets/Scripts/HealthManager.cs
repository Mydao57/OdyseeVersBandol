using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxhealth = 3f;
    public float health;
    private float damageTaken = 0f; // Nouvelle variable pour suivre les dégâts subis

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public SpriteRenderer player;
    private bool hasRotated = false;
    public PlayerMovement playerMovement;
    public AudioClip hit;
    public AudioClip death;


    void Start()
    {
        health = maxhealth;
        player = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                if (i == Mathf.FloorToInt(health - damageTaken)) // Si l'index correspond au cœur affecté par les dégâts
                {
                    hearts[i].sprite = halfHeart;
                }
                else
                {
                    hearts[i].sprite = fullHeart;
                }
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        // Vérifier si la vie est égale à 0
        if (health == 0f)
        {
            
            if ( !hasRotated)
            {
                AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
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

    // Méthode pour prendre des dégâts
    public void TakeDamage(float damage)
    {
        damageTaken += damage;
        health -= damage;
        AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);

        if (health < 0f)
        {
            health = 0f;
        }
    }

    public void InflictDamageOnClick()
    {
        TakeDamage(0.5f);
    }
}
