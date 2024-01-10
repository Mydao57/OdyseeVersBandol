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

    void Start()
    {
        health = maxhealth;
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
            // Charger une nouvelle scène (remplacez "NouvelleScene" par le nom de votre scène)
            SceneManager.LoadScene("GameOver");
        }
    }

    // Méthode pour prendre des dégâts
    public void TakeDamage(float damage)
    {
        damageTaken += damage;
        health -= damage;

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
