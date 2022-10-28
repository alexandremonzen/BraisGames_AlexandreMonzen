using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private Canvas _canvas;

    private void Awake()
    {
        if(!_mainCamera)
        {
            _mainCamera = Camera.main;
        }

        _canvas = GetComponent<Canvas>();
        if(_canvas)
        {
            _canvas.worldCamera = _mainCamera;
        }
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.forward, _mainCamera.transform.rotation * Vector3.up);
    }
}