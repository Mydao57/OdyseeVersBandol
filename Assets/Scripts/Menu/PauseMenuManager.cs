using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public KeyCode pauseKey = KeyCode.Escape;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Met en pause le temps dans le jeu
            ShowPauseMenu(true);
        }
        else
        {
            Time.timeScale = 1f; // Réactive le temps dans le jeu
            ShowPauseMenu(false);
        }
    }

    void ShowPauseMenu(bool show)
    {
        pauseMenuCanvas.SetActive(show);
    }

    public void BackToBar()
    {
        SceneManager.LoadScene("BarScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}