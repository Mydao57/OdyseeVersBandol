using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{

    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    [SerializeField] private AudioClip soundClip;

    // Start is called before the first frame update
    void Start()
    {
        _startingSceneTransition.SetActive(true);
        Invoke(nameof(DisableStartingSceneTransition), 5f);
    }

    private void DisableStartingSceneTransition() { 
        _startingSceneTransition.SetActive(false);

    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 ) {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position);
                _endingSceneTransition.SetActive(true);
                Invoke(nameof(LoadNextLevel), 1.5f);

            }
        }
        
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("BarScene");
    }
}
