using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName; // D�finissez ceci dans l'Inspecteur avec le nom de la sc�ne que vous voulez charger
    public AudioClip soundClip; // D�finissez ceci dans l'Inspecteur avec le clip audio que vous voulez jouer
    public float delayBeforeSceneChange = 0.5f; // Ajoutez un d�lai en secondes (ajustez selon vos pr�f�rences)

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

        // Attendre avant de changer de sc�ne
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Charger la sc�ne suivante
        SceneManager.LoadScene(nextSceneName);
    }
}
