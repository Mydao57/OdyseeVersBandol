using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float distanceToTrigger = 2f;
    public KeyCode dialogueKey = KeyCode.Space;
    public DialogueManager dialogueManager;
    public GameObject quete;

    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(dialogueKey))
        {
            StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Assurez-vous d'ajuster le tag selon vos besoins
        {
            quete.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            quete.SetActive(false);
            isInRange = false;
        }
    }

    private void StartDialogue()
    {
        // Déclenchez ici votre gestionnaire de dialogue
        dialogueManager.StartDialogue();
    }
}
