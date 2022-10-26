using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    [Header("Rotation Axis")]
    [SerializeField] private Vector3 _rotationVector = new Vector3(0f, 1f, 0f);
    [SerializeField] private float _rotationSpeed = 50;

    private bool _canRotate;

    private void OnEnable()
    {
        _canRotate = true;
        StartCoroutine(Rotate());
    }

    private void OnDisable()
    {
        _canRotate = false;
    }

    private IEnumerator Rotate()
    {
        while (_canRotate)
        {
            transform.Rotate(_rotationVector * _rotationSpeed * Time.deltaTime);
            yield return null;
        }  
    }
}
