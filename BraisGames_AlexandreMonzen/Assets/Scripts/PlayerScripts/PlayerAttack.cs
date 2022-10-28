using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

namespace PlayerCharacter
{
    public sealed class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Collider _hitCollider;
        [SerializeField] private string _attackAnimationName;
        [SerializeField] private float _timeToEnableHitCollider;
        [SerializeField] private float _timeFinishAttack;

        private bool _isAttacking;

        private PlayerMovement _playerMovement;
        private PlayerAnimation _playerAnimation;
        private PlayerInputActions _playerInputActions;

        [Header("Audio FMOD")]
        [SerializeField] private EventReference _swingAttackReference;
        private PlayAudioFMOD _playAudioFMOD;


        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _playAudioFMOD = GetComponent<PlayAudioFMOD>();

            _isAttacking = false;
            _hitCollider.enabled = false;
        }

        private void OnEnable()
        {
            _playerInputActions.PlayerAttackActionMap.Enable();
            _playerInputActions.PlayerAttackActionMap.Attack.performed += Attack;
        }

        private void OnDisable()
        {
            _playerInputActions.PlayerAttackActionMap.Attack.performed -= Attack;
            _playerInputActions.PlayerAttackActionMap.Disable();
        }

        private void Attack(InputAction.CallbackContext obj)
        {
            if (!_isAttacking)
            {
                StartCoroutine(AttackCoroutine());
            }
        }

        private IEnumerator AttackCoroutine()
        {
            _isAttacking = true;
            _playerAnimation.animator.SetTrigger(_attackAnimationName);
            _playAudioFMOD.PlaySound3D(_swingAttackReference, this.transform.position);
            yield return new WaitForSeconds(_timeToEnableHitCollider);

            _hitCollider.enabled = true;
            yield return new WaitForSeconds(_timeFinishAttack);

            _isAttacking = false;
            _hitCollider.enabled = false;

            yield return null;
        }
    }
}
