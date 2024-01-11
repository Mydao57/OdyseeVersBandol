using UnityEngine;
using UnityEngine.UI;

public class BackToBar : MonoBehaviour
{
    // Attache ce script à un GameObject contenant un bouton dans l'Inspector Unity

    void Start()
    {
        Button button = GetComponent<Button>();

        // Vérifie si le bouton est attaché
        if (button != null)
        {
            // Ajoute un écouteur d'événements pour le clic sur le bouton
            button.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogError("Ce script doit être attaché à un GameObject contenant un composant Button.");
        }
    }

    // Fonction appelée lorsque le bouton est cliqué
    void OnClick()
    {
        Debug.Log("Le bouton a été cliqué !");
    }
}
