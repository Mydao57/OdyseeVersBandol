using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnKeyPress : MonoBehaviour
{
    public string nomScene; // Ajoute le type de la variable (string)

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nomScene);
        }
    }
}
