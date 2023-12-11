using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;  // Vous pouvez utiliser un Canvas pour afficher le dialogue

    public void StartDialogue()
    {
        // Mettez en �uvre la logique pour afficher le dialogue ici
        dialogueCanvas.SetActive(true);
    }

    public void EndDialogue()
    {
        // Mettez en �uvre la logique pour terminer le dialogue ici
        dialogueCanvas.SetActive(false);
    }
}