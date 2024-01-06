using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName; // Définissez ceci dans l'Inspecteur avec le nom de la scène que vous voulez charger
    public AudioClip soundClip; // Définissez ceci dans l'Inspecteur avec le clip audio que vous voulez jouer
    public float delayBeforeSceneChange = 0.5f; // Ajoutez un délai en secondes (ajustez selon vos préférences)

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(ChangeSceneWithDelay());
        }
    }

    private IEnumerator ChangeSceneWithDelay()
    {
        // Jouer le son
        if (soundClip != null)
        {
            AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position);
        }

        // Attendre avant de changer de scène
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Charger la scène suivante
        SceneManager.LoadScene(nextSceneName);
    }
}
