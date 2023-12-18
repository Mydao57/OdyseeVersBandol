using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{

    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;

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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _endingSceneTransition.SetActive(true);
            Invoke(nameof(LoadNextLevel), 1.5f);
            
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("BarScene");
    }
}
