using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 3f;
    private float damageTaken = 0f; // Nouvelle variable pour suivre les d�g�ts subis

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                if (i == Mathf.FloorToInt(health - damageTaken)) // Si l'index correspond au c�ur affect� par les d�g�ts
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
    }

    // M�thode pour prendre des d�g�ts
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
