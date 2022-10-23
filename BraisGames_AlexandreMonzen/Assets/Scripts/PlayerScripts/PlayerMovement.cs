using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

///<summary>
///Simple script that simulates a camera relative movement
///</summary>

namespace PlayerCharacter
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        private CharacterController _characterController;
        private PlayerInputActions _playerInputActions;
        private InputAction _movementInputAction;

        #region Vectors
        private Vector2 _movementVector;
        private Vector3 _currentMovementVector;
        private Vector3 _smoothedMovementVector;
        private Vector3 _finalMovementVector;
        private Vector3 _refVelocityVector;
        private Vector3 _lookRotationVector;
        private Vector3 _gravityVector;
        #endregion

        [Header("Movement")]
        [SerializeField] private float _normalMoveSpeed = 3;
        [SerializeField][Range(1.5f, 3f)] private float _multiplierRunMoveSpeed = 2;
        [SerializeField][Range(0, 1)] private float _moveSmoothValue = 0.1f;
        [SerializeField][Range(0, 1)] private float _smoothRotationValue = 0.1f;
        private float _actualMoveSpeed;
        private float _runMoveSpeed;

        [Header("MoveSpeed Lerp Transitions")]
        [SerializeField] private float _timeNormalLerp;
        [SerializeField] private float _timeRunLerp;
        private bool _isWalking;
        private bool _isWalkingFast;
        private bool _isWalkingSlow;

        [Header("Gravity")]
        [SerializeField][Range(0, 100)] private float _defaultGravity = 9.81f;
        private float _actualGravity;
        private float _velocityY;

        [Header("Jump")]
        [SerializeField][Range(0, 100)] private float _jumpForce = 25;

        private bool _jumpPerformed;
        private bool _isOnAir;
        private bool _isFallingOnly;
        private bool _canWalk;
        private bool _canRotate;

        #region Camera Direction Vectors
        private Vector3 _camForward;
        private Vector3 _camRigth;
        #endregion

        #region Getters & Setters
        public CharacterController characterController { get => _characterController; set => _characterController = value; }
        public Vector3 FinalMovementVector { get => _finalMovementVector; }
        public float DefaultGravity { get => _defaultGravity; }
        public float ActualGravity { get => _actualGravity; set => _actualGravity = value; }
        public float VelocityY { get => _velocityY; }
        public bool IsOnAir { get => _isOnAir; }
        public bool IsFallingOnly { get => _isFallingOnly; set => _isFallingOnly = value; }
        #endregion

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerInputActions = new PlayerInputActions();

            if (!_camera)
            {
                _camera = Camera.main.gameObject;
            }

            _actualMoveSpeed = _normalMoveSpeed;
            _runMoveSpeed = _normalMoveSpeed * _multiplierRunMoveSpeed;

            _isWalking = false;
            _isWalkingFast = false;
            _isWalkingSlow = false;

            _refVelocityVector = Vector3.one;
            _velocityY = 0;
            _actualGravity = _defaultGravity;

            _canRotate = true;
            _canWalk = true;
        }

        private void OnEnable()
        {
            _movementInputAction = _playerInputActions.PlayerMovementActionMap.Movement;
            _movementInputAction.Enable();

            _playerInputActions.PlayerMovementActionMap.Jump.Enable();
            _playerInputActions.PlayerMovementActionMap.Jump.performed += PerformedJump;

            _playerInputActions.PlayerMovementActionMap.FastMovement.Enable();
            _playerInputActions.PlayerMovementActionMap.FastMovement.started += StartedFastMovement;
            _playerInputActions.PlayerMovementActionMap.FastMovement.canceled += CanceledFastMovement;

            _isWalkingFast = false;
            _isWalkingSlow = false;
            _actualMoveSpeed = _normalMoveSpeed;
            StopAllCoroutines();
        }

        private void OnDisable()
        {
            _movementInputAction.Disable();

            _playerInputActions.PlayerMovementActionMap.Jump.performed -= PerformedJump;
            _playerInputActions.PlayerMovementActionMap.Jump.Disable();

            _playerInputActions.PlayerMovementActionMap.FastMovement.started -= StartedFastMovement;
            _playerInputActions.PlayerMovementActionMap.FastMovement.canceled -= CanceledFastMovement;
            _playerInputActions.PlayerMovementActionMap.FastMovement.Disable();

            _isWalkingFast = false;
            _isWalkingSlow = false;
            _actualMoveSpeed = _normalMoveSpeed;
            StopAllCoroutines();
        }

        private void Update()
        {
            UpdateRelativeCameraVectors();

            HandleGravityJump();
            HandleMovement();
            HandleRotation();
            HandleCharacterController();
        }

        private void UpdateRelativeCameraVectors()
        {
            _camForward = _camera.transform.forward;
            _camForward.y = 0;
            _camForward = _camForward.normalized;

            _camRigth = _camera.transform.right;
            _camRigth.y = 0;
            _camRigth = _camRigth.normalized;
        }

        private void HandleGravityJump()
        {
            if (_characterController.isGrounded && _jumpPerformed)
            {
                _velocityY = _jumpForce;
                _jumpPerformed = false;
                _isOnAir = true;
                _isFallingOnly = false;
            }
            else if (_characterController.isGrounded && !_jumpPerformed)
            {
                _isOnAir = false;
                _isFallingOnly = false;
                _velocityY = -characterController.stepOffset * Time.deltaTime;
            }
            else if (!_characterController.isGrounded)
            {
                if (_velocityY < -4)
                {
                    _isFallingOnly = true;
                    _isOnAir = true;
                }

                _velocityY -= _actualGravity * Time.deltaTime;
            }
            _gravityVector = new Vector3(0, _velocityY, 0);
        }

        private void HandleMovement()
        {
            _movementVector = _movementInputAction.ReadValue<Vector2>();
            _currentMovementVector = Vector3.SmoothDamp(_currentMovementVector, _movementVector, ref _refVelocityVector, _moveSmoothValue);
            _smoothedMovementVector = new Vector3(_currentMovementVector.x * _actualMoveSpeed, _velocityY, _currentMovementVector.y * _actualMoveSpeed);

            _finalMovementVector = (_camRigth * _smoothedMovementVector.x) + _gravityVector + (_camForward * _smoothedMovementVector.z);
            _isWalking = (Mathf.Abs(_movementVector.x) > 0 || Mathf.Abs(_movementVector.y) > 0) ? true : false;
        }

        private void HandleRotation()
        {
            if (_canRotate)
            {
                _lookRotationVector = (_camRigth * _smoothedMovementVector.x) + (_camera.transform.up * 0) + (_camForward * _smoothedMovementVector.z);
                if (_lookRotationVector != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_lookRotationVector), _smoothRotationValue);
                }
            }
        }

        private void HandleCharacterController()
        {
            _characterController.Move(_finalMovementVector * Time.deltaTime);

        }

        public void FaceCharacterToObject(Transform target)
        {
            Vector3 targetPoint = target.position;
            targetPoint = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            transform.LookAt(targetPoint, Vector3.up);
        }

        public void ToggleMovementInputAction(bool on)
        {
            if (on)
            {
                _movementInputAction.Enable();
            }
            else
            {
                _movementInputAction.Disable();
            }
        }

        public void ToggleAllMovementType(bool on)
        {
            if (on)
            {
                _playerInputActions.PlayerMovementActionMap.Enable();
                _canRotate = true;
            }
            else
            {
                _playerInputActions.PlayerMovementActionMap.Disable();
                _canRotate = false;
            }
        }

        #region Actions Methods

        private void PerformedJump(InputAction.CallbackContext obj)
        {
            if (_characterController.isGrounded)
            {
                _jumpPerformed = true;
            }
        }

        private void StartedFastMovement(InputAction.CallbackContext obj)
        {
            if (_characterController.isGrounded)
            {
                if (!_isWalkingSlow)
                {
                    _isWalkingFast = true;
                    StartCoroutine(LerpMoveSpeedToRun());
                }
            }
        }

        private void CanceledFastMovement(InputAction.CallbackContext obj)
        {
            if (_isWalkingFast)
            {
                _isWalkingFast = false;
                StartCoroutine(LerpMoveSpeedToNormal());
            }
        }
        #endregion

        #region IEnumerators
        private IEnumerator LerpMoveSpeedToNormal()
        {
            float timeElapsed = 0;

            while (timeElapsed < _timeNormalLerp && (!_isWalkingFast && !_isWalkingSlow))
            {
                _actualMoveSpeed = Mathf.Lerp(_actualMoveSpeed, _normalMoveSpeed, timeElapsed / _timeNormalLerp);
                timeElapsed += 1 * Time.deltaTime;
                yield return null;
            }

            yield return null;
        }

        private IEnumerator LerpMoveSpeedToRun()
        {
            float timeElapsed = 0;

            while (timeElapsed < _timeRunLerp && _isWalkingFast && _characterController.isGrounded)
            {
                _actualMoveSpeed = Mathf.Lerp(_actualMoveSpeed, _runMoveSpeed, timeElapsed / _timeRunLerp);
                timeElapsed += 1 * Time.deltaTime;
                yield return null;
            }

            yield return null;
        }
        #endregion
    }
}
