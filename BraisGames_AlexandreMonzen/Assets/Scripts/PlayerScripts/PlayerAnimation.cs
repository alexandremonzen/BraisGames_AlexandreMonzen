using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public sealed class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private PlayerMovement _playerMovement;

        #region Getters & Setters
        public Animator animator { get => _animator; set => _animator = value; }
        #endregion
        
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void Update()
        {
            _animator.SetBool("isOnAir", _playerMovement.IsOnAir);
            _animator.SetBool("isFallingOnly", _playerMovement.IsFallingOnly);
            _animator.SetFloat("velocityY", _playerMovement.VelocityY);

            _animator.SetFloat("blendWalkX", Mathf.Abs(_playerMovement.FinalMovementVector.x));
            _animator.SetFloat("blendWalkY", Mathf.Abs(_playerMovement.FinalMovementVector.z));
        }
    }
}
