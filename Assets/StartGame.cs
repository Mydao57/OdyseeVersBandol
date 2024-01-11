using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float interactionDistance = 2f; // Distance à laquelle le joueur peut interagir avec le barman
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction

    private void Update()
    {
        // Vérifier si le joueur est dans la zone d'interaction et appuie sur la touche spécifiée
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {
            // Lancer votre jeu ou effectuer l'action désirée ici
            Invoke("loadGame", 1.5f);

            // Ajoutez votre code ici pour lancer votre jeu ou effectuer l'action souhaitée.
        }
    }

    public void loadGame()
    {
        SceneManager.LoadScene(2);

    }

    private bool IsPlayerInRange()
    {
        // Vérifier la distance entre le joueur et le barman
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Assurez-vous que votre joueur a le tag "Player"
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= interactionDistance;
        }

        return false;
    }
}
