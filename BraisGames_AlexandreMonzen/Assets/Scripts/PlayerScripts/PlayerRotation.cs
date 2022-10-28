using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

///<summary>
///Rotates the player character based on camera or mouse position
///</summary>

namespace PlayerCharacter
{
    public sealed class PlayerRotation : MonoBehaviour
    {
        [Header("Based on Camera")]
        [SerializeField] private Cinemachine.CinemachineInputProvider _cinemachineInput;

        [Tooltip("0.01 too much smooth <> 1 no smooth at all")]
        [SerializeField][Range(0.01f, 1)] private float _smoothRotationValue = 0.1f;
        private Vector2 _mousePosition;
        private Vector3 _lookRotationVector;
        private int _rotationType;
        private bool _canRotate;

        [Header("Based on Mouse Position")]
        [SerializeField][Range(0, 1000)] private float _rayLength = 100;
        private Ray _cameraRay;
        private Plane _groundPlane;
        private Vector3 _pointToLook;

        private PlayerMovement _playerMovement;
        private CameraRelativeVectors _cameraRelativeVectors;
        private PlayerInputActions _playerInputActions;
        private InputAction _mousePositionInputAction;
        private MouseStatusController _mouseStatusController;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _cameraRelativeVectors = GetComponent<CameraRelativeVectors>();
            _playerInputActions = new PlayerInputActions();
            _mouseStatusController = MouseStatusController.Instance;

            _rotationType = 0;
            _canRotate = true;

            _groundPlane = new Plane(Vector3.up, Vector3.zero);

            if(_cinemachineInput) _cinemachineInput.enabled = false;
        }

        private void OnEnable()
        {
            _playerInputActions.PlayerGeneralActionMap.LookRotation.Enable();
            _cinemachineInput.enabled = true;

            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.performed += SwitchRotationType;
            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.Enable();

            _mousePositionInputAction = _playerInputActions.PlayerGeneralActionMap.LookAtMousePosition;
            _mousePositionInputAction.Enable();
        }


        private void OnDisable()
        {
            _playerInputActions.PlayerGeneralActionMap.LookRotation.Disable();
            if(_cinemachineInput) _cinemachineInput.enabled = false;

            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.Disable();
            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.performed -= SwitchRotationType;

            _mousePositionInputAction.Disable();
        }

        private void Update()
        {
            UpdateMousePosition();
            HandleRotation();
        }

        private void UpdateMousePosition()
        {
            _mousePosition = _mousePositionInputAction.ReadValue<Vector2>();
        }

        private void HandleRotation()
        {
            if (_canRotate)
            {
                if (_rotationType == 0)
                {
                    _lookRotationVector = (_playerMovement.FinalMovementVector);
                    _lookRotationVector.y *= 0;
                    if (_lookRotationVector != Vector3.zero)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_lookRotationVector), _smoothRotationValue);
                    }
                }
                else
                {
                    _cameraRay = _cameraRelativeVectors.Camera.ScreenPointToRay(_mousePosition);

                    if (_groundPlane.Raycast(_cameraRay, out _rayLength))
                    {
                        _pointToLook = _cameraRay.GetPoint(_rayLength);

                        _lookRotationVector = new Vector3(_pointToLook.x, 0, _pointToLook.z);
                        transform.LookAt(new Vector3(_pointToLook.x, transform.position.y, _pointToLook.z));
                    }
                }
            }
        }

        private void SwitchRotationType(InputAction.CallbackContext obj)
        {
            _rotationType += 1;

            if (_rotationType >= 2) _rotationType = 0;

            if (_rotationType == 0)
            {
                _playerInputActions.PlayerGeneralActionMap.LookRotation.Enable();
                _cinemachineInput.enabled = true;
                _mouseStatusController.SetMouseVisibilityAndLockState(false, CursorLockMode.Locked);
            }
            else
            {
                _playerInputActions.PlayerGeneralActionMap.LookRotation.Disable();
                _cinemachineInput.enabled = false;
                _mouseStatusController.SetMouseVisibilityAndLockState(true, CursorLockMode.None);
            }
        }


        public void RemoveAllRotationType()
        {
            _canRotate = false;
            _cinemachineInput.enabled = false;

            _playerInputActions.PlayerGeneralActionMap.LookRotation.Disable();
            _mousePositionInputAction.Disable();

            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.Disable();
            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.performed -= SwitchRotationType;
        }

        public void ReturnAllRotationType()
        {
            _canRotate = true;
            _cinemachineInput.enabled = true;

            _playerInputActions.PlayerGeneralActionMap.LookRotation.Enable();
            _mousePositionInputAction.Enable();

            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.performed += SwitchRotationType;
            _playerInputActions.PlayerGeneralActionMap.SwitchRotationType.Enable();
        }
    }
}