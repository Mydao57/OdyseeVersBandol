using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float interactionDistance = 2f; // Distance � laquelle le joueur peut interagir avec le barman
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction

    private void Update()
    {
        // V�rifier si le joueur est dans la zone d'interaction et appuie sur la touche sp�cifi�e
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {
            // Lancer votre jeu ou effectuer l'action d�sir�e ici
            Invoke("loadGame", 1.5f);

            // Ajoutez votre code ici pour lancer votre jeu ou effectuer l'action souhait�e.
        }
    }

    public void loadGame()
    {
        SceneManager.LoadScene(2);

    }

    private bool IsPlayerInRange()
    {
        // V�rifier la distance entre le joueur et le barman
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Assurez-vous que votre joueur a le tag "Player"
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= interactionDistance;
        }

        return false;
    }
}
