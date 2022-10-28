using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerCharacter;

public sealed class Main : Singleton<Main>
{
    [Header("Core")]
    private PauseManager _pauseManager;

    [Header("Player")]
    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;

    private void Awake()
    {
        _pauseManager = FindObjectOfType<PauseManager>();

        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerRotation = _playerMovement.GetComponent<PlayerRotation>();
    }

    private void Start()
    {
        _pauseManager.PauseGameAction += _playerMovement.RemoveAllMovementType;
        _pauseManager.UnPauseGameAction += _playerMovement.ReturnAllMovementType;

        _pauseManager.PauseGameAction += _playerRotation.RemoveAllRotationType;
        _pauseManager.UnPauseGameAction += _playerRotation.ReturnAllRotationType;
    }

    private void OnDisable()
    {
        _pauseManager.PauseGameAction -= _playerMovement.RemoveAllMovementType;
        _pauseManager.UnPauseGameAction -= _playerMovement.ReturnAllMovementType;

        _pauseManager.PauseGameAction -= _playerRotation.RemoveAllRotationType;
        _pauseManager.UnPauseGameAction -= _playerRotation.ReturnAllRotationType;
    }
}
