using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    [Header("Canva Prefab")]
    [SerializeField] private GameObject _pauseMenuCanvas;
    
    private bool _paused;
    private MouseStatusController _mouseStatusController;

    public event Action PauseGameAction;
    public event Action UnPauseGameAction;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _mouseStatusController = MouseStatusController.Instance;

        _paused = false;
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _playerInputActions.GeneralActionMap.Enable();

        _playerInputActions.GeneralActionMap.Pause.Enable();
        _playerInputActions.GeneralActionMap.Pause.performed += PauseOrUnpauseGame;

        PauseGameAction += PauseGame;
        UnPauseGameAction += UnpauseGame;
    }

    private void OnDisable()
    {
        _playerInputActions.GeneralActionMap.Disable();

        _playerInputActions.GeneralActionMap.Pause.Disable();
        _playerInputActions.GeneralActionMap.Pause.performed -= PauseOrUnpauseGame;

        PauseGameAction -= PauseGame;
        UnPauseGameAction -= UnpauseGame;
    }

    private void PauseOrUnpauseGame(InputAction.CallbackContext obj)
    {
        if (!_paused)
        {
            PauseGameAction();
        }
        else
        {
            UnPauseGameAction();
        }
    }

    public void ReturnGameButtonUI()
    {
        UnPauseGameAction();
    }

    public void PauseGame()
    {
        _paused = true;
        _pauseMenuCanvas.SetActive(true);
        _mouseStatusController.SetMouseVisibilityAndLockState(true, CursorLockMode.None);

        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        _paused = false;
        _pauseMenuCanvas.SetActive(false);
        _mouseStatusController.SetMouseVisibilityAndLockState(false, CursorLockMode.Locked);

        Time.timeScale = 1;
    }

    public void LoadScene(int sceneIndex)
    {
        _paused = false;
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}