using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRelativeVectors : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    #region Camera Direction Vectors
    private Vector3 _camForward;
    private Vector3 _camRigth;

    public Vector3 CamForward { get => _camForward;  }
    public Vector3 CamRigth { get => _camRigth; }
    public Camera Camera { get => _camera; }
    #endregion

    private void Awake()
    {
        if (!_camera)
        {
            _camera = Camera.main;
        }
    }

    private void Update()
    {
        UpdateRelativeCameraVectors();
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
}
