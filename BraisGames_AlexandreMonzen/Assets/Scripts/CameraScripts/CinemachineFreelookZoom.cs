using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;

public class CinemachineFreelookZoom : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _zoomSpeed = 1;
    [SerializeField] private float _zoomAcceleration = 2.5f;

    [Header("Rigs Radius")]
    [SerializeField] private float _minTopRadius = 1f;
    [SerializeField] private float _maxTopRadius = 3f;

    [SerializeField] private float _minMiddleRadius = 1f;
    [SerializeField] private float _maxMiddleRadius = 3f;

    [SerializeField] private float _minBottomRadius = 1f;
    [SerializeField] private float _maxBottomRadius = 3f;

    [Header("Rigs Heights")]
    [SerializeField] private float _minTopHeight = 1f;
    [SerializeField] private float _maxTopHeight = 3f;

    [SerializeField] private float _minMiddleHeight = 1f;
    [SerializeField] private float _maxMiddleHeight = 3f;

    [SerializeField] private float _minBottomHeight = 1f;
    [SerializeField] private float _maxBottomHeight = 3f;

    #region Radius variables
    private float _currentTopRadius;
    private float _newTopRadius;
    private float _currentBottomRadius;
    private float _newBottomRadius;
    private float _currentMiddleRadius;
    private float _newMiddleRadius;
    #endregion

    #region Height variables
    private float _currentTopHeight;
    private float _newTopHeight;
    private float _currentMiddleHeight;
    private float _newMiddleHeight;
    private float _currentBottomHeight;
    private float _newBottomHeight;
    #endregion

    private float _zoomAxisY;
    public float ZoomAxisY
    {
        get { return _zoomAxisY; }
        set
        {
            if (_zoomAxisY == value) return;
            _zoomAxisY = value;
            AdjustCameraZoomIndex(ZoomAxisY);
        }
    }

    private CinemachineFreeLook _cinemachine;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _cinemachine = GetComponent<CinemachineFreeLook>();

        _currentTopRadius = _cinemachine.m_Orbits[0].m_Radius;
        _currentMiddleRadius = _cinemachine.m_Orbits[1].m_Radius;
        _currentBottomRadius = _cinemachine.m_Orbits[2].m_Radius;

        _currentTopHeight = _cinemachine.m_Orbits[0].m_Height;
        _currentMiddleHeight = _cinemachine.m_Orbits[1].m_Height;
        _currentBottomHeight = _cinemachine.m_Orbits[2].m_Height;

        _newTopRadius = _currentTopRadius;
        _newMiddleRadius = _currentMiddleRadius;
        _newBottomRadius = _currentBottomRadius;

        _newTopHeight = _currentTopHeight;
        _newMiddleHeight = _currentMiddleHeight;
        _newBottomHeight = _currentBottomHeight;
    }

    private void OnEnable()
    {
        _playerInputActions.PlayerGeneralActionMap.Enable();
        _playerInputActions.PlayerGeneralActionMap.LookZoom.performed += ZoomPerformed;
        _playerInputActions.PlayerGeneralActionMap.LookZoom.canceled += ZoomCanceled;
    }

    private void OnDisable()
    {
        _playerInputActions.PlayerGeneralActionMap.LookZoom.performed -= ZoomPerformed;
        _playerInputActions.PlayerGeneralActionMap.LookZoom.canceled -= ZoomCanceled;
        _playerInputActions.PlayerGeneralActionMap.Disable();
    }

    private void LateUpdate()
    {
        UpdateZoomLevel();
    }

    private void UpdateZoomLevel()
    {
        if (_currentMiddleRadius == _newMiddleRadius) { return; }

        _currentTopRadius = Mathf.Lerp(_currentTopRadius, _newTopRadius, _zoomAcceleration * Time.deltaTime);
        _currentMiddleRadius = Mathf.Lerp(_currentMiddleRadius, _newMiddleRadius, _zoomAcceleration * Time.deltaTime);
        _currentBottomRadius = Mathf.Lerp(_currentBottomRadius, _newBottomRadius, _zoomAcceleration * Time.deltaTime);

        _currentTopHeight = Mathf.Lerp(_currentTopHeight, _newTopHeight, _zoomAcceleration * Time.deltaTime);
        _currentMiddleHeight = Mathf.Lerp(_currentMiddleHeight, _newMiddleHeight, _zoomAcceleration * Time.deltaTime);
        _currentBottomHeight = Mathf.Lerp(_currentBottomHeight, _newBottomHeight, _zoomAcceleration * Time.deltaTime);

        _currentTopRadius = Mathf.Clamp(_currentTopRadius, _minTopRadius, _maxTopRadius);
        _currentMiddleRadius = Mathf.Clamp(_currentMiddleRadius, _minMiddleRadius, _maxMiddleRadius);
        _currentBottomRadius = Mathf.Clamp(_currentBottomRadius, _minBottomRadius, _maxBottomRadius);

        _currentTopHeight = Mathf.Clamp(_currentTopHeight, _minTopHeight, _maxTopHeight);
        _currentMiddleHeight = Mathf.Clamp(_currentMiddleHeight, _minMiddleHeight, _maxMiddleHeight);
        _currentBottomHeight = Mathf.Clamp(_currentBottomHeight, _minBottomHeight, _maxBottomHeight);

        _cinemachine.m_Orbits[0].m_Radius = _currentTopRadius;
        _cinemachine.m_Orbits[1].m_Radius = _currentMiddleRadius;
        _cinemachine.m_Orbits[2].m_Radius = _currentBottomRadius;

        _cinemachine.m_Orbits[0].m_Height = _currentTopHeight;
        _cinemachine.m_Orbits[1].m_Height = _currentMiddleHeight;
        _cinemachine.m_Orbits[2].m_Height = _currentBottomHeight;
    }

    private void ZoomPerformed(InputAction.CallbackContext context)
    {
        ZoomAxisY = context.ReadValue<float>();
    }

    private void ZoomCanceled(InputAction.CallbackContext context)
    {
        ZoomAxisY = 0;
    }

    private void AdjustCameraZoomIndex(float zoomAxisY)
    {
        if (zoomAxisY == 0) return;

        if (zoomAxisY < 0)
        {
            _newTopRadius = _currentTopRadius + _zoomSpeed;
            _newMiddleRadius = _currentMiddleRadius + _zoomSpeed;
            _newBottomRadius = _currentBottomRadius + _zoomSpeed;

            _newTopHeight = _currentTopHeight + _zoomSpeed;
            _newMiddleHeight = _currentMiddleHeight + _zoomSpeed;
            _newBottomHeight = _currentBottomHeight + _zoomSpeed;
        }

        if (zoomAxisY > 0)
        {
            _newMiddleRadius = _currentMiddleRadius - _zoomSpeed;
            _newBottomRadius = _currentBottomRadius - _zoomSpeed;
            _newTopRadius = _currentTopRadius - _zoomSpeed;

            _newTopHeight = _currentTopHeight - _zoomSpeed;
            _newMiddleHeight = _currentMiddleHeight - _zoomSpeed;
            _newBottomHeight = _currentBottomHeight - _zoomSpeed;
        }
    }
}