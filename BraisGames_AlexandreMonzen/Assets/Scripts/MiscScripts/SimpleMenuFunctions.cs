using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SimpleMenuFunctions : MonoBehaviour
{
    private PauseManager _pauseManager;

    private void Awake()
    {
        _pauseManager = FindObjectOfType<PauseManager>();
    }

    public void ResumeGame()
    {
        _pauseManager.UnpauseGame();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
