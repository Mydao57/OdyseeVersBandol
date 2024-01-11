using UnityEngine;
using UnityEngine.UI;

public class BackToBar : MonoBehaviour
{
    // Attache ce script � un GameObject contenant un bouton dans l'Inspector Unity

    void Start()
    {
        Button button = GetComponent<Button>();

        // V�rifie si le bouton est attach�
        if (button != null)
        {
            // Ajoute un �couteur d'�v�nements pour le clic sur le bouton
            button.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogError("Ce script doit �tre attach� � un GameObject contenant un composant Button.");
        }
    }

    // Fonction appel�e lorsque le bouton est cliqu�
    void OnClick()
    {
        Debug.Log("Le bouton a �t� cliqu� !");
    }
}
