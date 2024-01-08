using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool hasCheckedEnemies = false;

    void Update()
    {
        if (!hasCheckedEnemies)
        {
            CheckForNoEnemies();
        }
    }

    void CheckForNoEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            Debug.Log("Il n'y a plus d'ennemis dans la sc�ne.");
            // Ajoutez d'autres actions � effectuer lorsque tous les ennemis sont �limin�s.
        }

        hasCheckedEnemies = true;
    }
}
